using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace OTTCreator.WebApp.ViewModels;

public class UserViewModel
{
    public string Id { get; set; }

    [Display(Name = "Електронна пошта")]
    public string Email { get; set; }

    [DataType(DataType.Password)]
    [Display(Name = "Пароль")]
    public string Password { get; set; }

    [Display(Name = "Підтвердження пароля")]
    [DataType(DataType.Password)]
    public string ConfirmPassword { get; set; }

    public List<SelectListItem> Roles { get; set; } = new List<SelectListItem>();

    [Display(Name = "Роль")]
    public string RoleId { get; set; }

    [Display(Name = "Оплачено")]
    public bool IsAllowed { get; set; }
}
