using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using OTTCreator.Web.Areas.Identity.Data;
using System.Reflection.Emit;

namespace OTTCreator.Web.Data;

public class ApplicationIdentityDbContext : IdentityDbContext<User>
{
    public ApplicationIdentityDbContext(DbContextOptions<ApplicationIdentityDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<User>()
        .Property(b => b.DevicesAndCodes)
        .HasConversion(
            v => JsonConvert.SerializeObject(v),
            v => JsonConvert.DeserializeObject<Dictionary<string, Guid>>(v));
    }
}
