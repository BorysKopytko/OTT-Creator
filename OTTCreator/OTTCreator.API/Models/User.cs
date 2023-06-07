using Microsoft.AspNetCore.Identity;

namespace OTTCreator.WebAPI.Models;

public class User : IdentityUser
{
    public Dictionary<Guid, bool> CodesAndUse { get; set; } 
    public List<int> FavoriteContentItemsIDs { get; set; }
}
