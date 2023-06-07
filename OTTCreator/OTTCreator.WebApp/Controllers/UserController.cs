using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OTTCreator.WebApp.Areas.Identity.Data;
using OTTCreator.WebApp.Models;
using OTTCreator.WebApp.Repositories.Interfaces;
using OTTCreator.WebApp.ViewModels;

namespace OTTCreator.WebApp.Controllers
{
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
            List<UserListViewModel> model = new List<UserListViewModel>();
            var administrators = await userManager.GetUsersInRoleAsync("Адміністратор");
            var users = await userManager.GetUsersInRoleAsync("Користувач");
            foreach (var administrator in administrators)
            {
                model.Add(new UserListViewModel { Id = administrator.Id, Email = administrator.Email, Role = "Адміністратор" });
            }
            foreach (var user in users)
            {
                model.Add(new UserListViewModel { Id = user.Id, Email = user.Email, Role = "Користувач" });
            }

            return View(model);
        }

        //GET
        public IActionResult CreateChoose()
        {
            var model = new ChooseRoleViewModel();
            model.Roles = roleManager.Roles.Select(r => new SelectListItem { Value = r.Name, Text = r.Name }).ToList();
            return View(model);
        }

        //POST
        [HttpPost]
        public async Task<IActionResult> CreateChoose(ChooseRoleViewModel chooseRoleViewModel)
        {
            if (chooseRoleViewModel.Role == "Адміністратор")
            {
                return RedirectToAction(nameof(CreateAdministrator));
            }
            else if (chooseRoleViewModel.Role == "Користувач")
            {
                return RedirectToAction(nameof(CreateUser));
            }
            return View();
        }

        public IActionResult CreateAdministrator()
        {
            var UserViewModel = new UserViewModel();
            UserViewModel.Roles.Add(new SelectListItem { Value = roleManager.Roles.FirstOrDefault(x => x.Name == "Адміністратор").Id, Text = "Адміністратор" });
            return View(UserViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAdministrator(UserViewModel model)
        {
            var administrator = new User();

            administrator.Email = model.Email;

            await repositoryWrapper.UserRepository.AddAsync(administrator);
            await unitOfWork.Commit();

            User user = new User
            {
                UserName = model.Email,
                Email = model.Email,
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
            IdentityResult result = await userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                Role Role = await roleManager.FindByNameAsync("Адміністратор");
                if (Role != null)
                {
                    IdentityResult roleResult = await userManager.AddToRoleAsync(user, Role.Name);
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
            var UserViewModel = new UserViewModel();
            UserViewModel.Roles.Add(new SelectListItem { Value = roleManager.Roles.FirstOrDefault(x => x.Name == "Користувач").Id, Text = "Користувач" });
            return View(UserViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(UserViewModel model)
        {
            var _user = new User();
            _user.Email = model.Email;

            await repositoryWrapper.UserRepository.AddAsync(_user);
            await unitOfWork.Commit();

            User user = new User
            {
                UserName = model.Email,
                Email = model.Email,
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
            IdentityResult result = await userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                Role Role = await roleManager.FindByNameAsync("Користувач");
                if (Role != null)
                {
                    IdentityResult roleResult = await userManager.AddToRoleAsync(user, Role.Name);
                    if (roleResult.Succeeded)
                    {
                        return RedirectToAction(nameof(Configure));
                    }
                }
            }

            return View("CreateUser", model);
        }

        [HttpGet]
        public async Task<IActionResult> EditAdministrator(string id)
        {
            UserViewModel model = new UserViewModel();

            var administrator = await repositoryWrapper.UserRepository.GetByIdAsync((id));

            model.Email = administrator.Email;

            if (!String.IsNullOrEmpty(id))
            {
                User user = await userManager.FindByEmailAsync(administrator.Email);
                if (user != null)
                {
                    model.Email = user.Email;
                }
            }
            return View(nameof(EditAdministrator), model);
        }

        [HttpPost]
        public async Task<IActionResult> EditAdministrator(string id, UserViewModel model)
        {
            User user = await userManager.FindByEmailAsync(model.Email);
            var administrator = await repositoryWrapper.UserRepository.GetByIdAsync((id));

            administrator.Email = model.Email;

            await repositoryWrapper.UserRepository.UpdateAsync(administrator);
            await unitOfWork.Commit();

            if (user != null)
            {
                user.Email = model.Email;
                user.UserName = model.Email;
                IdentityResult result = await userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Configure));
                }
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
            var model = new UserViewModel();

            var _user = await repositoryWrapper.UserRepository.GetByIdAsync((id));

            model.Email = _user.Email;


            if (!String.IsNullOrEmpty(id))
            {
                User user = await userManager.FindByEmailAsync(_user.Email);
                if (user != null)
                {
                    model.Email = user.Email;
                }
            }
            return View(nameof(EditUser), model);
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(string id, UserViewModel model)
        {
            User user = await userManager.FindByEmailAsync(model.Email);
            var _user = await repositoryWrapper.UserRepository.GetByIdAsync((id));

            _user.Email = model.Email;

            await repositoryWrapper.UserRepository.UpdateAsync(_user);
            await unitOfWork.Commit();

            if (user != null)
            {
                user.Email = model.Email;
                user.UserName = model.Email;
                IdentityResult result = await userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Configure));
                }
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
            if (!String.IsNullOrEmpty(id))
            {
                User User = await userManager.FindByIdAsync(id);
                if (User != null)
                {
                    name = User.Email;
                }
            }
            return View(nameof(Delete), name);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteAdministrator(string id)
        {
            UserViewModel model = new UserViewModel();

            var administrator = await repositoryWrapper.UserRepository.GetByIdAsync((id));

            model.Email = administrator.Email;

            if (!String.IsNullOrEmpty(id))
            {
                User user = await userManager.FindByEmailAsync(administrator.Email);
                if (user != null)
                {
                    model.Email = user.Email;
                }
            }
            return View(nameof(DeleteAdministrator), model);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var model = new UserViewModel();

            var _user = await repositoryWrapper.UserRepository.GetByIdAsync((id));

            model.Email = _user.Email;

            if (!String.IsNullOrEmpty(id))
            {
                User user = await userManager.FindByEmailAsync(_user.Email);
                if (user != null)
                {
                    model.Email = user.Email;
                }
            }
            return View(nameof(DeleteUser), model);
        }

        [HttpPost]
        [ActionName("DeleteAdministrator")]
        public async Task<IActionResult> DeleteAdministratorPOST(string id)
        {
            var administrator = await repositoryWrapper.UserRepository.GetByIdAsync((id));
            if (!String.IsNullOrEmpty(id))
            {
                User User = await userManager.FindByEmailAsync(administrator.Email);
                if (User != null)
                {
                    IdentityResult result = await userManager.DeleteAsync(User);
                    if (result.Succeeded)
                    {
                        await repositoryWrapper.UserRepository.DeleteAsync(administrator);
                        await unitOfWork.Commit();
                        return RedirectToAction(nameof(Configure));
                    }
                }
            }
            return RedirectToAction(nameof(Configure));
        }

        [HttpPost]
        [ActionName("DeleteUser")]
        public async Task<IActionResult> DeleteUserPOST(string id)
        {
            var _user = await repositoryWrapper.UserRepository.GetByIdAsync((id));
            if (!String.IsNullOrEmpty(id))
            {
                User User = await userManager.FindByEmailAsync(_user.Email);
                if (User != null)
                {
                    IdentityResult result = await userManager.DeleteAsync(User);
                    if (result.Succeeded)
                    {
                        await repositoryWrapper.UserRepository.DeleteAsync(_user);
                        await unitOfWork.Commit();
                        return RedirectToAction(nameof(Configure));
                    }
                }
            }
            return RedirectToAction(nameof(Configure));
        }
    }
}
