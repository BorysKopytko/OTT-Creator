using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OTTCreator.WebApp.Areas.Identity.Data;
using OTTCreator.WebApp.Models;
using OTTCreator.WebApp.Repositories.Interfaces;
using OTTCreator.WebApp.ViewModels;

namespace OTTCreator.WebApp.Controllers;

public class UserController : Controller
{
    private readonly UserManager<User> userManager;
    private readonly RoleManager<Role> roleManager;
    private readonly IRepositoryWrapper repositoryWrapper;
    private readonly IUnitOfWork unitOfWork;

    public UserController(UserManager<User> userManager, RoleManager<Role> roleManager, IRepositoryWrapper repositoryWrapper, IUnitOfWork unitOfWork)
    {
        this.userManager = userManager;
        this.roleManager = roleManager;
        this.repositoryWrapper = repositoryWrapper;
        this.unitOfWork = unitOfWork;
    }

    [Authorize(Roles = "Адміністратор")]
    public async Task<IActionResult> Configure()
    {
        var model = new List<UserListViewModel>();

        var administrators = await userManager.GetUsersInRoleAsync("Адміністратор");
        var users = await userManager.GetUsersInRoleAsync("Клієнт");
        foreach (var administrator in administrators)
            model.Add(new UserListViewModel { Id = administrator.Id, Email = administrator.Email, PhoneNumber = administrator.PhoneNumber, Role = "Адміністратор", IsAllowed = administrator.IsAllowed });
        foreach (var user in users)
            model.Add(new UserListViewModel { Id = user.Id, Email = user.Email, PhoneNumber = user.PhoneNumber, Role = "Клієнт", IsAllowed = user.IsAllowed });

        return View(model);
    }

    public IActionResult CreateChoose()
    {
        return View(new ChooseRoleViewModel() { Roles = roleManager.Roles.Select(r => new SelectListItem { Value = r.Name, Text = r.Name }).ToList() });
    }

    [HttpPost]
    public async Task<IActionResult> CreateChoose(ChooseRoleViewModel chooseRoleViewModel)
    {
        if (chooseRoleViewModel.Role == "Адміністратор")
            return RedirectToAction(nameof(CreateAdministrator));
        else if (chooseRoleViewModel.Role == "Клієнт")
            return RedirectToAction(nameof(CreateUser));
        return View();
    }

    public IActionResult CreateAdministrator()
    {
        return View(new UserViewModel() { Roles = new List<SelectListItem> { new SelectListItem { Value = roleManager.Roles.FirstOrDefault(x => x.Name == "Адміністратор").Id, Text = "Адміністратор" } } });
    }

    [HttpPost]
    public async Task<IActionResult> CreateAdministrator(UserViewModel model)
    {
        var user = new User
        {
            UserName = model.Email,
            PhoneNumber = model.PhoneNumber,
            Email = model.Email,
            IsAllowed = true,
            FavoriteContentItemsIDs = new List<int>(),
            CodesAndUse = new Dictionary<Guid, bool>
            {
                {Guid.NewGuid(), false },
                {Guid.NewGuid(), false },
                {Guid.NewGuid(), false },
                {Guid.NewGuid(), false },
                {Guid.NewGuid(), false }
            }
        };

        var result = await userManager.CreateAsync(user, model.Password);
        if (result.Succeeded)
        {
            var Role = await roleManager.FindByNameAsync("Адміністратор");
            if (Role != null)
            {
                var roleResult = await userManager.AddToRoleAsync(user, Role.Name);
                if (roleResult.Succeeded)
                {
                    return RedirectToAction(nameof(Configure));
                }
            }
        }

        return View("CreateAdministrator", model);
    }

    public IActionResult CreateUser()
    {
        return View(new UserViewModel() { Roles = new List<SelectListItem> { new SelectListItem { Value = roleManager.Roles.FirstOrDefault(x => x.Name == "Клієнт").Id, Text = "Клієнт" } } });
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser(UserViewModel model)
    {
        var user = new User
        {
            UserName = model.Email,
            Email = model.Email,
            PhoneNumber = model.PhoneNumber,
            IsAllowed = true,
            FavoriteContentItemsIDs = new List<int>(),
            CodesAndUse = new Dictionary<Guid, bool>
            {
                {Guid.NewGuid(), false },
                {Guid.NewGuid(), false },
                {Guid.NewGuid(), false },
                {Guid.NewGuid(), false },
                {Guid.NewGuid(), false }
            }
        };
        var result = await userManager.CreateAsync(user, model.Password);
        if (result.Succeeded)
        {
            var Role = await roleManager.FindByNameAsync("Клієнт");
            if (Role != null)
            {
                var roleResult = await userManager.AddToRoleAsync(user, Role.Name);
                if (roleResult.Succeeded)
                    return RedirectToAction(nameof(Configure));
            }
        }

        return View("CreateUser", model);
    }

    [HttpGet]
    public async Task<IActionResult> EditAdministrator(string id)
    {
        var administrator = await repositoryWrapper.UserRepository.GetByIdAsync((id));

        var model = new UserViewModel()
        {
            Email = administrator.Email,
            PhoneNumber = administrator.PhoneNumber
        };

        if (!string.IsNullOrEmpty(id))
        {
            var user = await userManager.FindByEmailAsync(administrator.Email);
            if (user != null)
            {
                model.Email = user.Email;
                model.IsAllowed = user.IsAllowed;
            }
        }
        return View(nameof(EditAdministrator), model);
    }

    [HttpPost]
    public async Task<IActionResult> EditAdministrator(string id, UserViewModel model)
    {
        var user = await userManager.FindByEmailAsync(model.Email);

        var administrator = await repositoryWrapper.UserRepository.GetByIdAsync((id));
        administrator.Email = model.Email;

        if (user != null)
        {
            user.Email = model.Email;
            user.UserName = model.Email;
            user.PhoneNumber = model.PhoneNumber;
            user.IsAllowed = model.IsAllowed;

            var result = await userManager.UpdateAsync(user);
            if (result.Succeeded)
                return RedirectToAction(nameof(Configure));
        }
        else
        {
            return RedirectToAction(nameof(Configure));
        }

        return View(nameof(EditAdministrator), model);
    }

    [HttpGet]
    public async Task<IActionResult> EditUser(string id)
    {
        var _user = await repositoryWrapper.UserRepository.GetByIdAsync((id));

        var model = new UserViewModel()
        {
            Email = _user.Email,
            PhoneNumber = _user.PhoneNumber
        };

        if (!string.IsNullOrEmpty(id))
        {
            var user = await userManager.FindByEmailAsync(_user.Email);
            if (user != null)
            {
                model.Email = user.Email;
                model.IsAllowed = user.IsAllowed;
            }
        }
        return View(nameof(EditUser), model);
    }

    [HttpPost]
    public async Task<IActionResult> EditUser(string id, UserViewModel model)
    {
        var user = await userManager.FindByEmailAsync(model.Email);

        var _user = await repositoryWrapper.UserRepository.GetByIdAsync((id));
        _user.Email = model.Email;

        if (user != null)
        {
            user.Email = model.Email;
            user.UserName = model.Email;
            user.PhoneNumber = model.PhoneNumber;
            user.IsAllowed = model.IsAllowed;
            var result = await userManager.UpdateAsync(user);
            if (result.Succeeded)
                return RedirectToAction(nameof(Configure));
        }
        else
        {
            return RedirectToAction(nameof(Configure));
        }

        return View(nameof(EditUser), model);
    }

    [HttpGet]
    public async Task<IActionResult> Delete(string id)
    {
        string name = string.Empty;
        if (!string.IsNullOrEmpty(id))
        {
            var User = await userManager.FindByIdAsync(id);
            if (User != null)
                name = User.Email;
        }
        return View(nameof(Delete), name);
    }

    [HttpGet]
    public async Task<IActionResult> DeleteAdministrator(string id)
    {
        var model = new UserViewModel();

        var administrator = await repositoryWrapper.UserRepository.GetByIdAsync((id));

        model.Email = administrator.Email;

        if (!string.IsNullOrEmpty(id))
        {
            var user = await userManager.FindByEmailAsync(administrator.Email);
            if (user != null)
                model.Email = user.Email;
        }
        return View(nameof(DeleteAdministrator), model);
    }

    [HttpGet]
    public async Task<IActionResult> DeleteUser(string id)
    {
        var model = new UserViewModel();

        var _user = await repositoryWrapper.UserRepository.GetByIdAsync((id));

        model.Email = _user.Email;

        if (!string.IsNullOrEmpty(id))
        {
            var user = await userManager.FindByEmailAsync(_user.Email);
            if (user != null)
                model.Email = user.Email;
        }
        return View(nameof(DeleteUser), model);
    }

    [HttpPost]
    [ActionName("DeleteAdministrator")]
    public async Task<IActionResult> DeleteAdministratorPOST(string id)
    {
        var administrator = await repositoryWrapper.UserRepository.GetByIdAsync((id));
        if (!string.IsNullOrEmpty(id))
        {
            var User = await userManager.FindByEmailAsync(administrator.Email);
            if (User != null)
            {
                var result = await userManager.DeleteAsync(User);
                if (result.Succeeded)
                    return RedirectToAction(nameof(Configure));
            }
        }
        return RedirectToAction(nameof(Configure));
    }

    [HttpPost]
    [ActionName("DeleteUser")]
    public async Task<IActionResult> DeleteUserPOST(string id)
    {
        var _user = await repositoryWrapper.UserRepository.GetByIdAsync((id));
        if (!string.IsNullOrEmpty(id))
        {
            var User = await userManager.FindByEmailAsync(_user.Email);
            if (User != null)
            {
                IdentityResult result = await userManager.DeleteAsync(User);
                if (result.Succeeded)
                    return RedirectToAction(nameof(Configure));
            }
        }
        return RedirectToAction(nameof(Configure));
    }
}
