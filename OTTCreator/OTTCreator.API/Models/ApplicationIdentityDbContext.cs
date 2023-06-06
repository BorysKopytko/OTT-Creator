using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace OTTCreator.API.Models;

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

        builder.Entity<ContentItem>().HasData(
            new ContentItem
            {
                ID = 1,
                Name = "Test content 1",
                Category = "Test category A",
                Type = "Телеканали",
                HasVideo = true,
                Image = new Uri("https://www.photos-public-domain.com/wp-content/uploads/2016/08/tortie-cat-300x300.jpg"),
                CroppedImage = new Uri("https://www.photos-public-domain.com/wp-content/uploads/2016/08/tortie-cat-300x300.jpg"),
                Stream = new Uri("https://bloomberg.com/media-manifest/streams/eu.m3u8")
            },
            new ContentItem
            {
                ID = 2,
                Name = "Test content 2",
                Category = "Test category A",
                Type = "Телеканали",
                HasVideo = true,
                CroppedImage = new Uri("https://www.photos-public-domain.com/wp-content/uploads/2016/08/tortie-cat-300x300.jpg"),
                Image = new Uri("https://cdn.pixabay.com/photo/2023/04/11/22/08/flower-7918323_960_720.jpg"),
                Stream = new Uri("https://i.mjh.nz/PlutoTV/5a6b92f6e22a617379789618-alt.m3u8")
            },
            new ContentItem
            {
                ID = 3,
                Name = "Test content 3",
                Category = "Test category B",
                Type = "Телеканали",
                HasVideo = true,
                CroppedImage = new Uri("https://www.photos-public-domain.com/wp-content/uploads/2016/08/tortie-cat-300x300.jpg"),
                Image = new Uri("https://cdn.pixabay.com/photo/2023/04/11/22/08/flower-7918323_960_720.jpg"),
                Stream = new Uri("https://ythls.onrender.com/channel/UCH9H_b9oJtSHBovh94yB5HA.m3u8")
            },
            new ContentItem
            {
                ID = 4,
                Name = "Test content 4",
                Category = "Test category B",
                Type = "Телеканали",
                HasVideo = true,
                CroppedImage = new Uri("https://www.photos-public-domain.com/wp-content/uploads/2016/08/tortie-cat-300x300.jpg"),
                Image = new Uri("https://cdn.pixabay.com/photo/2023/04/11/22/08/flower-7918323_960_720.jpg"),
                Stream = new Uri("https://ythls.onrender.com/channel/UCMEiyV8N2J93GdPNltPYM6w.m3u8")
            },
            new ContentItem
            {
                ID = 5,
                Name = "Test content 5",
                Category = "Test category C",
                Type = "Радіостанції",
                HasVideo = false,
                CroppedImage = new Uri("https://www.photos-public-domain.com/wp-content/uploads/2016/08/tortie-cat-300x300.jpg"),
                Image = new Uri("https://cdn.pixabay.com/photo/2023/04/11/22/08/flower-7918323_960_720.jpg"),
                Stream = new Uri("https://online.hitfm.ua/HitFM_HD")
            },
            new ContentItem
            {
                ID = 6,
                Name = "Test content 6",
                Category = "Test category C",
                Type = "Радіостанції",
                HasVideo = false,
                CroppedImage = new Uri("https://www.photos-public-domain.com/wp-content/uploads/2016/08/tortie-cat-300x300.jpg"),
                Image = new Uri("https://cdn.pixabay.com/photo/2023/04/11/22/08/flower-7918323_960_720.jpg"),
                Stream = new Uri("https://online.radioroks.ua/RadioROKS_HD")
            },
            new ContentItem
            {
                ID = 7,
                Name = "Test content 7",
                Category = "Test category D",
                Type = "Радіостанції",
                HasVideo = false,
                CroppedImage = new Uri("https://www.photos-public-domain.com/wp-content/uploads/2016/08/tortie-cat-300x300.jpg"),
                Image = new Uri("https://cdn.pixabay.com/photo/2023/04/11/22/08/flower-7918323_960_720.jpg"),
                Stream = new Uri("https://online.hitfm.ua/HitFM_HD")
            },
            new ContentItem
            {
                ID = 8,
                Name = "Test content 8",
                Category = "Test category D",
                Type = "Радіостанції",
                HasVideo = true,
                CroppedImage = new Uri("https://www.photos-public-domain.com/wp-content/uploads/2016/08/tortie-cat-300x300.jpg"),
                Image = new Uri("https://cdn.pixabay.com/photo/2023/04/11/22/08/flower-7918323_960_720.jpg"),
                Stream = new Uri("http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/BigBuckBunny.mp4")
            }
        );
    }
}
