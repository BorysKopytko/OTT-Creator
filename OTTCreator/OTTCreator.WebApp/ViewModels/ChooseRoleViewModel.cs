using Microsoft.AspNetCore.Mvc.Rendering;

namespace OTTCreator.WebApp.ViewModels;

public class ChooseRoleViewModel
{
    public string Role { get; set; }
    public List<SelectListItem> Roles { get; set; } = new List<SelectListItem>();
}
