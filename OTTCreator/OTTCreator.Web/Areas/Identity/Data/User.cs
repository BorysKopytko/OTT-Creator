using Microsoft.AspNetCore.Identity;

namespace OTTCreator.Web.Areas.Identity.Data;

public class User : IdentityUser
{
    public Dictionary<Guid, bool> CodesAndUse { get; set; }
    public List<int> FavoriteContentItemsIDs { get; set; }
}
