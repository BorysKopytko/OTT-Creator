using System.ComponentModel.DataAnnotations;

namespace OTTCreator.WebApp.ViewModels;

public class LoginViewModel
{
    [Required]
    [DataType(DataType.EmailAddress)]
    public string UserName { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Display(Name = "Запам'ятати мене")]
    public bool RememberMe { get; set; }
}
