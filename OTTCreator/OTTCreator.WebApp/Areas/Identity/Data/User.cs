using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace OTTCreator.WebApp.Areas.Identity.Data;

// Add profile data for application users by adding properties to the OTTCreatorWebAppUser class
public class User : IdentityUser
{
    public Dictionary<Guid, bool> CodesAndUse { get; set; }
    public List<int> FavoriteContentItemsIDs { get; set; }
}

