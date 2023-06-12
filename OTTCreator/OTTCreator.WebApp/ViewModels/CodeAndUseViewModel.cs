using System.ComponentModel.DataAnnotations;

namespace OTTCreator.WebApp.ViewModels;

public class CodeAndUseViewModel
{
    [Display(Name = "Код")]
    public string Code { get; set; }

    [Display(Name = "Використовується")]
    public bool IsUsing { get; set; }
}
