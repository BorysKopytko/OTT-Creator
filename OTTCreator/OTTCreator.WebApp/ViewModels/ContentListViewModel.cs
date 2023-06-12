using System.ComponentModel.DataAnnotations;

namespace OTTCreator.WebApp.ViewModels;

public class ContentListViewModel
{
    public string Id { get; set; }

    [Display(Name = "Назва")]
    public string Name { get; set; }

    [Display(Name = "Категорія")]
    public string Category { get; set; }

    [Display(Name = "Тип")]
    public string Type { get; set; }

    [Display(Name = "Зображення")]
    public Uri Image { get; set; }

    [Display(Name = "Логотип")]
    public Uri CroppedImage { get; set; }

    [Display(Name = "Потік")]
    public Uri Stream { get; set; }

    [Display(Name = "Є відео?")]
    public bool HasVideo { get; set; }
}
