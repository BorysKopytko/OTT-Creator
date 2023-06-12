using Microsoft.AspNetCore.Identity;

namespace OTTCreator.WebApp.Areas.Identity.Data;

public class User : IdentityUser
{
    public Dictionary<Guid, bool> CodesAndUse { get; set; }
    public List<int> FavoriteContentItemsIDs { get; set; }
    public bool IsAllowed { get; set; }
}
