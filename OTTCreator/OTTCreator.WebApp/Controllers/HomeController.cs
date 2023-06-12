using Microsoft.AspNetCore.Mvc;
using OTTCreator.WebApp.Models;
using OTTCreator.WebApp.Repositories.Interfaces;
using OTTCreator.WebApp.ViewModels;
using System.Diagnostics;
using System.Security.Claims;

namespace OTTCreator.WebApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IRepositoryWrapper repositoryWrapper;
    private readonly IUnitOfWork unitOfWork;

    public HomeController(ILogger<HomeController> logger, IRepositoryWrapper repositoryWrapper, IUnitOfWork unitOfWork)
    {
        _logger = logger;
        this.repositoryWrapper = repositoryWrapper;
        this.unitOfWork = unitOfWork;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public async Task<IActionResult> CodesAndUseAsync()
    {
        var codesAndUse = await repositoryWrapper.UserRepository.GetByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));
        var codesAndUseViewModel = new List<CodeAndUseViewModel>();
        foreach (var codeAndUse in codesAndUse.CodesAndUse)
            codesAndUseViewModel.Add(new CodeAndUseViewModel { Code = codeAndUse.Key.ToString(), IsUsing = codeAndUse.Value });
        return View(codesAndUseViewModel);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
