using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OTTCreator.WebApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate102 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ContentItems",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "Category", "Name" },
                values: new object[] { "Новинні", "Суспільне Новини" });

            migrationBuilder.UpdateData(
                table: "ContentItems",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "Category", "CroppedImage", "Image", "Name", "Stream" },
                values: new object[] { "Новинні", "https://s6.vcdn.biz/static/f/4632098541/image.jpg/pt/r300x423x4", "https://s1.vcdn.biz/static/f/5898897271/image.jpg/pt/r300x423x4", "АРМІЯ ТБ", "https://euronews-euronews-world-1-au.samsung.wurl.com/manifest/playlist.m3u8" });

            migrationBuilder.UpdateData(
                table: "ContentItems",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "Category", "CroppedImage", "Image", "Name" },
                values: new object[] { "Пізнавальні", "https://s9.vcdn.biz/static/f/5354553681/image.jpg/pt/r300x423x4", "https://s6.vcdn.biz/static/f/4632098541/image.jpg/pt/r300x423x4", "Суспільне Культура" });

            migrationBuilder.UpdateData(
                table: "ContentItems",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "Category", "CroppedImage", "Image", "Name" },
                values: new object[] { "Новинні", "https://s9.vcdn.biz/static/f/5354553681/image.jpg/pt/r300x423x4", "https://s9.vcdn.biz/static/f/4632113151/image.jpg/pt/r300x423x4", "Перший" });

            migrationBuilder.UpdateData(
                table: "ContentItems",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "Category", "CroppedImage", "Image", "Name", "Stream" },
                values: new object[] { "Новинні", "https://s1.vcdn.biz/static/f/333958501/image.jpg/pt/r300x423x4", "https://s1.vcdn.biz/static/f/333958501/image.jpg/pt/r300x423x4", "Київ", "https://fashiontv-fashiontv-1-eu.rakuten.wurl.tv/playlist.m3u8" });

            migrationBuilder.UpdateData(
                table: "ContentItems",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "Category", "CroppedImage", "Image", "Name", "Stream" },
                values: new object[] { "Новинні", "https://s9.vcdn.biz/static/f/5354553681/image.jpg/pt/r300x423x4", "https://s2.vcdn.biz/static/f/4961863001/image.jpg/pt/r300x423x4", "5 канал", "https://ythls.onrender.com/channel/UCQfwfsi5VrQ8yKZ-UWmAEFg.m3u8" });

            migrationBuilder.UpdateData(
                table: "ContentItems",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "Category", "CroppedImage", "Image", "Name", "Stream" },
                values: new object[] { "Новинні", "https://s1.vcdn.biz/static/f/672118741/image.jpg/pt/r300x423x4", "https://s1.vcdn.biz/static/f/672118741/image.jpg/pt/r300x423x4", "Еспресо TV", "https://live-tf1-hls-dai.cdn-1.diff.tf1.fr/out/v1/c2e382be3aa2486e8753747e7bb6157e/index.m3u8" });

            migrationBuilder.UpdateData(
                table: "ContentItems",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "Category", "CroppedImage", "Image", "Name", "Stream" },
                values: new object[] { "Новинні", "https://s9.vcdn.biz/static/f/5016844881/image.jpg/pt/r300x423x4", "https://s9.vcdn.biz/static/f/5016844881/image.jpg/pt/r300x423x4", "BBC World News", "https://cnn-cnninternational-1-eu.rakuten.wurl.tv/playlist.m3u8" });

            migrationBuilder.InsertData(
                table: "ContentItems",
                columns: new[] { "ID", "Category", "CroppedImage", "HasVideo", "Image", "Name", "Stream", "Type" },
                values: new object[,]
                {
                    { 9, "Новинні", "https://s9.vcdn.biz/static/f/5016844881/image.jpg/pt/r300x423x4", true, "https://s9.vcdn.biz/static/f/5016844881/image.jpg/pt/r300x423x4", "TVP World", "https://cnn-cnninternational-1-eu.rakuten.wurl.tv/playlist.m3u8", "Телеканали" },
                    { 10, "Пізнавальні", "https://s9.vcdn.biz/static/f/5354553681/image.jpg/pt/r300x423x4", true, "https://s9.vcdn.biz/static/f/5354553681/image.jpg/pt/r300x423x4", "Суспільне Новини", "https://bloomberg.com/media-manifest/streams/eu.m3u8", "Телеканали" },
                    { 11, "Міжнародні", "https://s9.vcdn.biz/static/f/5016844881/image.jpg/pt/r300x423x4", true, "https://s9.vcdn.biz/static/f/5016844881/image.jpg/pt/r300x423x4", "TVP World", "https://cnn-cnninternational-1-eu.rakuten.wurl.tv/playlist.m3u8", "Радіостанції" },
                    { 12, "Національні", "https://play.tavr.media/static/image/header_menu/hit_efir_210x210.png", true, "https://play.tavr.media/static/image/header_menu/hit_efir_210x210.png", "Хіт FM", "https://online.hitfm.ua/HitFM_HD", "Радіостанції" },
                    { 13, "Національні", "https://play.tavr.media/static/image/header_menu/roks_efir_162x162.png", true, "https://play.tavr.media/static/image/header_menu/roks_efir_162x162.png", "Radio Roks", "https://online.radioroks.ua/RadioROKS_HD", "Радіостанції" },
                    { 14, "Національні", "https://play.tavr.media/static/image/header_menu/kiss_efir_210x210.png", true, "https://play.tavr.media/static/image/header_menu/kiss_efir_210x210.png", "Kiss FM", "https://online.kissfm.ua/KissFM_HD", "Радіостанції" },
                    { 15, "Національні", "https://play.tavr.media/static/image/header_menu/Relax_Efir_228x228.png", true, "https://play.tavr.media/static/image/header_menu/Relax_Efir_228x228.png", "Relax", "https://online.radiorelax.ua/RadioRelax_HD", "Радіостанції" },
                    { 16, "Місцеві", "https://play.tavr.media/static/image/header_menu/hit_efir_210x210.png", true, "https://play.tavr.media/static/image/header_menu/hit_efir_210x210.png", "Хіт FM", "https://online.hitfm.ua/HitFM_HD", "Радіостанції" },
                    { 17, "", "https://play.tavr.media/static/image/header_menu/Relax_Efir_228x228.png", true, "https://play.tavr.media/static/image/header_menu/Relax_Efir_228x228.png", "Relax", "https://online.radiorelax.ua/RadioRelax_HD", "Розмовні" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ContentItems",
                keyColumn: "ID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ContentItems",
                keyColumn: "ID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ContentItems",
                keyColumn: "ID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ContentItems",
                keyColumn: "ID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "ContentItems",
                keyColumn: "ID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "ContentItems",
                keyColumn: "ID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "ContentItems",
                keyColumn: "ID",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "ContentItems",
                keyColumn: "ID",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "ContentItems",
                keyColumn: "ID",
                keyValue: 17);

            migrationBuilder.UpdateData(
                table: "ContentItems",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "Category", "Name" },
                values: new object[] { "Test category A", "Test content 1" });

            migrationBuilder.UpdateData(
                table: "ContentItems",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "Category", "CroppedImage", "Image", "Name", "Stream" },
                values: new object[] { "Test category A", "https://www.photos-public-domain.com/wp-content/uploads/2016/08/tortie-cat-300x300.jpg", "https://cdn.pixabay.com/photo/2023/04/11/22/08/flower-7918323_960_720.jpg", "Test content 2", "https://i.mjh.nz/PlutoTV/5a6b92f6e22a617379789618-alt.m3u8" });

            migrationBuilder.UpdateData(
                table: "ContentItems",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "Category", "CroppedImage", "Image", "Name" },
                values: new object[] { "Test category B", "https://www.photos-public-domain.com/wp-content/uploads/2016/08/tortie-cat-300x300.jpg", "https://cdn.pixabay.com/photo/2023/04/11/22/08/flower-7918323_960_720.jpg", "Test content 3" });

            migrationBuilder.UpdateData(
                table: "ContentItems",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "Category", "CroppedImage", "Image", "Name" },
                values: new object[] { "Test category B", "https://www.photos-public-domain.com/wp-content/uploads/2016/08/tortie-cat-300x300.jpg", "https://cdn.pixabay.com/photo/2023/04/11/22/08/flower-7918323_960_720.jpg", "Test content 4" });

            migrationBuilder.UpdateData(
                table: "ContentItems",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "Category", "CroppedImage", "Image", "Name", "Stream" },
                values: new object[] { "Test category C", "https://www.photos-public-domain.com/wp-content/uploads/2016/08/tortie-cat-300x300.jpg", "https://cdn.pixabay.com/photo/2023/04/11/22/08/flower-7918323_960_720.jpg", "Test content 5", "https://online.hitfm.ua/HitFM_HD" });

            migrationBuilder.UpdateData(
                table: "ContentItems",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "Category", "CroppedImage", "Image", "Name", "Stream" },
                values: new object[] { "Test category C", "https://www.photos-public-domain.com/wp-content/uploads/2016/08/tortie-cat-300x300.jpg", "https://cdn.pixabay.com/photo/2023/04/11/22/08/flower-7918323_960_720.jpg", "Test content 6", "https://online.radioroks.ua/RadioROKS_HD" });

            migrationBuilder.UpdateData(
                table: "ContentItems",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "Category", "CroppedImage", "Image", "Name", "Stream" },
                values: new object[] { "Test category D", "https://www.photos-public-domain.com/wp-content/uploads/2016/08/tortie-cat-300x300.jpg", "https://cdn.pixabay.com/photo/2023/04/11/22/08/flower-7918323_960_720.jpg", "Test content 7", "https://online.hitfm.ua/HitFM_HD" });

            migrationBuilder.UpdateData(
                table: "ContentItems",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "Category", "CroppedImage", "Image", "Name", "Stream" },
                values: new object[] { "Test category D", "https://www.photos-public-domain.com/wp-content/uploads/2016/08/tortie-cat-300x300.jpg", "https://cdn.pixabay.com/photo/2023/04/11/22/08/flower-7918323_960_720.jpg", "Test content 8", "http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/BigBuckBunny.mp4" });
        }
    }
}
