using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace OTTCreator.Web.Areas.Identity.Data;

// Add profile data for application users by adding properties to the User class
public class User : IdentityUser
{
    public Dictionary<Guid, bool> CodesAndUse { get; set; }
    public List<int> FavoriteContentItemsIDs { get; set; }
}
