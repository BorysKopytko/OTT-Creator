using System.ComponentModel.DataAnnotations;

namespace OTTCreator.WebApp.ViewModels;

public class UserListViewModel
{
    public string Id { get; set; }

    [Display(Name = "Електронна пошта")]
    public string Email { get; set; }

    [Display(Name = "Номер телефону")]
    public string PhoneNumber { get; set; }

    [Display(Name = "Роль")]
    public string Role { get; set; }

    [Display(Name = "Оплачено")]
    public bool IsAllowed { get; set; }
}
