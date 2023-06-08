using System.ComponentModel.DataAnnotations;

namespace OTTCreator.WebApp.ViewModels;

public class RoleViewModel
{
    public string Id { get; set; }

    [Display(Name = "Роль")]
    public string RoleName { get; set; }
}
