using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace OTTCreator.WebAPI.Models;

public class ApplicationIdentityDbContext : IdentityDbContext<User>
{
    public ApplicationIdentityDbContext(DbContextOptions<ApplicationIdentityDbContext> options) : base(options) { }

    public DbSet<ContentItem> ContentItems { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=OTTCreator;Trusted_Connection=True;MultipleActiveResultSets=true");

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<User>()
        .Property(b => b.CodesAndUse)
        .HasConversion(
            v => JsonConvert.SerializeObject(v),
            v => JsonConvert.DeserializeObject<Dictionary<Guid, bool>>(v));

        builder.Entity<User>()
        .Property(b => b.FavoriteContentItemsIDs)
        .HasConversion(
            v => JsonConvert.SerializeObject(v),
            v => JsonConvert.DeserializeObject<List<int>>(v));
    }
}
