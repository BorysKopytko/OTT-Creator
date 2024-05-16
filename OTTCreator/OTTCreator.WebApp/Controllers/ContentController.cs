using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OTTCreator.WebApp.Models;
using OTTCreator.WebApp.Repositories.Interfaces;
using OTTCreator.WebApp.ViewModels;

namespace OTTCreator.WebApp.Controllers;

public class ContentController : Controller
{
    private readonly IRepositoryWrapper repositoryWrapper;
    private readonly IUnitOfWork unitOfWork;

    public ContentController(IRepositoryWrapper repositoryWrapper, IUnitOfWork unitOfWork)
    {
        this.repositoryWrapper = repositoryWrapper;
        this.unitOfWork = unitOfWork;
    }

    [Authorize(Roles = "Адміністратор")]
    public async Task<IActionResult> Configure()
    {
        var model = new List<ContentListViewModel>();
        var contentItems = await repositoryWrapper.ContentRepository.GetAllAsync();

        foreach (var contentItem in contentItems)
        {
            model.Add(new ContentListViewModel { Id = contentItem.ID.ToString(), Name = contentItem.Name, Category = contentItem.Category, Type = contentItem.Type, Image = contentItem.Image, CroppedImage = contentItem.CroppedImage, Stream = contentItem.Stream, HasVideo = contentItem.HasVideo });
        }

        return View(model);
    }

    public IActionResult Create()
    {
        var ContentListViewModel = new ContentListViewModel();
        return View(ContentListViewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Create(ContentListViewModel model)
    {
        var contentItem = new ContentItem()
        {
            Name = model.Name,
            Category = model.Category,
            Type = model.Type,
            Image = model.Image,
            CroppedImage = model.CroppedImage,
            Stream = model.Stream,
            HasVideo = model.HasVideo
        };

        await repositoryWrapper.ContentRepository.AddAsync(contentItem);
        await unitOfWork.Commit();

        return RedirectToAction(nameof(Configure));
    }

    [HttpGet]
    public async Task<IActionResult> Edit(string id)
    {
        var contentItem = await repositoryWrapper.ContentRepository.GetFirstOrDefaultAsync(x => x.ID == Convert.ToInt32(id));

        var model = new ContentListViewModel()
        {
            Name = contentItem.Name,
            Category = contentItem.Category,
            Type = contentItem.Type,
            Image = contentItem.Image,
            CroppedImage = contentItem.CroppedImage,
            Stream = contentItem.Stream,
            HasVideo = contentItem.HasVideo
        };

        return View(nameof(Edit), model);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(string id, ContentListViewModel model)
    {
        var contentItem = await repositoryWrapper.ContentRepository.GetFirstOrDefaultAsync(x => x.ID == Convert.ToInt32(id));

        contentItem.Name = model.Name;
        contentItem.Category = model.Category;
        contentItem.Type = model.Type;
        contentItem.Image = model.Image;
        contentItem.CroppedImage = model.CroppedImage;
        contentItem.Stream = model.Stream;
        contentItem.HasVideo = model.HasVideo;

        await repositoryWrapper.ContentRepository.UpdateAsync(contentItem);
        await unitOfWork.Commit();

        return RedirectToAction(nameof(Configure));
    }

    [HttpGet]
    public async Task<IActionResult> Delete(string id)
    {
        var contentItem = await repositoryWrapper.ContentRepository.GetFirstOrDefaultAsync(x => x.ID == Convert.ToInt32(id));

        var model = new ContentListViewModel()
        {
            Name = contentItem.Name,
            Category = contentItem.Category,
            Type = contentItem.Type,
            Image = contentItem.Image,
            CroppedImage = contentItem.CroppedImage,
            Stream = contentItem.Stream,
            HasVideo = contentItem.HasVideo
        };

        return View(nameof(Delete), model);
    }

    [HttpPost]
    [ActionName("Delete")]
    public async Task<IActionResult> DeletePOST(string id)
    {
        var contentItem = await repositoryWrapper.ContentRepository.GetFirstOrDefaultAsync(x => x.ID == Convert.ToInt32(id));
        await repositoryWrapper.ContentRepository.DeleteAsync(contentItem);
        await unitOfWork.Commit();
        return RedirectToAction(nameof(Configure));
    }
}
