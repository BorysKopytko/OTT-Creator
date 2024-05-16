using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using OTTCreator.WebApp.Areas.Identity.Data;
using OTTCreator.WebApp.Models;

namespace OTTCreator.WebApp.Data;

public class ApplicationIdentityDbContext : IdentityDbContext<User, Role, string>
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
                Name = "Суспільне Новини",
                Category = "Новинні",
                Type = "Телеканали",
                HasVideo = true,
                Image = new Uri("https://s9.vcdn.biz/static/f/5354553681/image.jpg/pt/r300x423x4"),
                CroppedImage = new Uri("https://s9.vcdn.biz/static/f/5354553681/image.jpg/pt/r300x423x4"),
                Stream = new Uri("https://bloomberg.com/media-manifest/streams/eu.m3u8")
            },
            new ContentItem
            {
                ID = 2,
                Name = "АРМІЯ ТБ",
                Category = "Новинні",
                Type = "Телеканали",
                HasVideo = true,
                CroppedImage = new Uri("https://s1.vcdn.biz/static/f/5898897271/image.jpg/pt/r300x423x4"),
                Image = new Uri("https://s1.vcdn.biz/static/f/5898897271/image.jpg/pt/r300x423x4"),
                Stream = new Uri("https://euronews-euronews-world-1-au.samsung.wurl.com/manifest/playlist.m3u8")
            },
            new ContentItem
            {
                ID = 3,
                Name = "Суспільне Культура",
                Category = "Пізнавальні",
                Type = "Телеканали",
                HasVideo = true,
                CroppedImage = new Uri("https://s6.vcdn.biz/static/f/4632098541/image.jpg/pt/r300x423x4"),
                Image = new Uri("https://s6.vcdn.biz/static/f/4632098541/image.jpg/pt/r300x423x4"),
                Stream = new Uri("https://ythls.onrender.com/channel/UCH9H_b9oJtSHBovh94yB5HA.m3u8")
            },
            new ContentItem
            {
                ID = 4,
                Name = "Перший",
                Category = "Новинні",
                Type = "Телеканали",
                HasVideo = true,
                CroppedImage = new Uri("https://s9.vcdn.biz/static/f/4632113151/image.jpg/pt/r300x423x4"),
                Image = new Uri("https://s9.vcdn.biz/static/f/4632113151/image.jpg/pt/r300x423x4"),
                Stream = new Uri("https://ythls.onrender.com/channel/UCMEiyV8N2J93GdPNltPYM6w.m3u8")
            },
            new ContentItem
            {
                ID = 5,
                Name = "Київ",
                Category = "Новинні",
                Type = "Телеканали",
                HasVideo = true,
                CroppedImage = new Uri("https://s8.vcdn.biz/static/f/6004218941/image.jpg/pt/r300x423x4"),
                Image = new Uri("https://s8.vcdn.biz/static/f/6004218941/image.jpg/pt/r300x423x4"),
                Stream = new Uri("https://fashiontv-fashiontv-1-eu.rakuten.wurl.tv/playlist.m3u8")
            },
            new ContentItem
            {
                ID = 6,
                Name = "5 канал",
                Category = "Новинні",
                Type = "Телеканали",
                HasVideo = true,
                CroppedImage = new Uri("https://s1.vcdn.biz/static/f/333958501/image.jpg/pt/r300x423x4"),
                Image = new Uri("https://s1.vcdn.biz/static/f/333958501/image.jpg/pt/r300x423x4"),
                Stream = new Uri("https://ythls.onrender.com/channel/UCQfwfsi5VrQ8yKZ-UWmAEFg.m3u8")
            },
            new ContentItem
            {
                ID = 7,
                Name = "Еспресо TV",
                Category = "Новинні",
                Type = "Телеканали",
                HasVideo = true,
                CroppedImage = new Uri("https://s2.vcdn.biz/static/f/4961863001/image.jpg/pt/r300x423x4"),
                Image = new Uri("https://s2.vcdn.biz/static/f/4961863001/image.jpg/pt/r300x423x4"),
                Stream = new Uri("https://live-tf1-hls-dai.cdn-1.diff.tf1.fr/out/v1/c2e382be3aa2486e8753747e7bb6157e/index.m3u8")
            },
            new ContentItem
            {
                ID = 8,
                Name = "BBC World News",
                Category = "Новинні",
                Type = "Телеканали",
                HasVideo = true,
                CroppedImage = new Uri("https://s1.vcdn.biz/static/f/672118741/image.jpg/pt/r300x423x4"),
                Image = new Uri("https://s1.vcdn.biz/static/f/672118741/image.jpg/pt/r300x423x4"),
                Stream = new Uri("https://cnn-cnninternational-1-eu.rakuten.wurl.tv/playlist.m3u8")
            },
            new ContentItem
            {
                ID = 9,
                Name = "TVP World",
                Category = "Новинні",
                Type = "Телеканали",
                HasVideo = true,
                CroppedImage = new Uri("https://s9.vcdn.biz/static/f/5016844881/image.jpg/pt/r300x423x4"),
                Image = new Uri("https://s9.vcdn.biz/static/f/5016844881/image.jpg/pt/r300x423x4"),
                Stream = new Uri("https://cnn-cnninternational-1-eu.rakuten.wurl.tv/playlist.m3u8")
            },
            new ContentItem
            {
                ID = 10,
                Name = "Суспільне Новини",
                Category = "Пізнавальні",
                Type = "Телеканали",
                HasVideo = true,
                Image = new Uri("https://s9.vcdn.biz/static/f/5354553681/image.jpg/pt/r300x423x4"),
                CroppedImage = new Uri("https://s9.vcdn.biz/static/f/5354553681/image.jpg/pt/r300x423x4"),
                Stream = new Uri("https://bloomberg.com/media-manifest/streams/eu.m3u8")
            },
            new ContentItem
            {
                ID = 11,
                Name = "TVP World",
                Category = "Міжнародні",
                Type = "Телеканали",
                HasVideo = true,
                CroppedImage = new Uri("https://s9.vcdn.biz/static/f/5016844881/image.jpg/pt/r300x423x4"),
                Image = new Uri("https://s9.vcdn.biz/static/f/5016844881/image.jpg/pt/r300x423x4"),
                Stream = new Uri("https://cnn-cnninternational-1-eu.rakuten.wurl.tv/playlist.m3u8")
            },
            new ContentItem
            {
                ID = 12,
                Name = "Хіт FM",
                Category = "Національні",
                Type = "Радіостанції",
                HasVideo = false,
                CroppedImage = new Uri("https://play.tavr.media/static/image/header_menu/hit_efir_210x210.png"),
                Image = new Uri("https://play.tavr.media/static/image/header_menu/hit_efir_210x210.png"),
                Stream = new Uri("https://online.hitfm.ua/HitFM_HD")
            },
            new ContentItem
            {
                ID = 13,
                Name = "Radio Roks",
                Category = "Національні",
                Type = "Радіостанції",
                HasVideo = false,
                CroppedImage = new Uri("https://play.tavr.media/static/image/header_menu/roks_efir_162x162.png"),
                Image = new Uri("https://play.tavr.media/static/image/header_menu/roks_efir_162x162.png"),
                Stream = new Uri("https://online.radioroks.ua/RadioROKS_HD")
            },
            new ContentItem
            {
                ID = 14,
                Name = "Kiss FM",
                Category = "Національні",
                Type = "Радіостанції",
                HasVideo = false,
                CroppedImage = new Uri("https://play.tavr.media/static/image/header_menu/kiss_efir_210x210.png"),
                Image = new Uri("https://play.tavr.media/static/image/header_menu/kiss_efir_210x210.png"),
                Stream = new Uri("https://online.kissfm.ua/KissFM_HD")
            },
            new ContentItem
            {
                ID = 15,
                Name = "Relax",
                Category = "Національні",
                Type = "Радіостанції",
                HasVideo = false,
                CroppedImage = new Uri("https://play.tavr.media/static/image/header_menu/Relax_Efir_228x228.png"),
                Image = new Uri("https://play.tavr.media/static/image/header_menu/Relax_Efir_228x228.png"),
                Stream = new Uri("https://online.radiorelax.ua/RadioRelax_HD")
            },
            new ContentItem
            {
                ID = 16,
                Name = "Хіт FM",
                Category = "Місцеві",
                Type = "Радіостанції",
                HasVideo = false,
                CroppedImage = new Uri("https://play.tavr.media/static/image/header_menu/hit_efir_210x210.png"),
                Image = new Uri("https://play.tavr.media/static/image/header_menu/hit_efir_210x210.png"),
                Stream = new Uri("https://online.hitfm.ua/HitFM_HD")
            },
            new ContentItem
            {
                ID = 17,
                Name = "Relax",
                Category = "Розмовні",
                Type = "Радіостанції",
                HasVideo = true,
                CroppedImage = new Uri("https://play.tavr.media/static/image/header_menu/Relax_Efir_228x228.png"),
                Image = new Uri("https://play.tavr.media/static/image/header_menu/Relax_Efir_228x228.png"),
                Stream = new Uri("https://online.radiorelax.ua/RadioRelax_HD")
            }
        );
    }
}
