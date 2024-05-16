using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OTTCreator.WebApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate103 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ContentItems",
                keyColumn: "ID",
                keyValue: 2,
                column: "CroppedImage",
                value: "https://s1.vcdn.biz/static/f/5898897271/image.jpg/pt/r300x423x4");

            migrationBuilder.UpdateData(
                table: "ContentItems",
                keyColumn: "ID",
                keyValue: 3,
                column: "CroppedImage",
                value: "https://s6.vcdn.biz/static/f/4632098541/image.jpg/pt/r300x423x4");

            migrationBuilder.UpdateData(
                table: "ContentItems",
                keyColumn: "ID",
                keyValue: 4,
                column: "CroppedImage",
                value: "https://s9.vcdn.biz/static/f/4632113151/image.jpg/pt/r300x423x4");

            migrationBuilder.UpdateData(
                table: "ContentItems",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CroppedImage", "HasVideo", "Image", "Type" },
                values: new object[] { "https://s8.vcdn.biz/static/f/6004218941/image.jpg/pt/r300x423x4", true, "https://s8.vcdn.biz/static/f/6004218941/image.jpg/pt/r300x423x4", "Телеканали" });

            migrationBuilder.UpdateData(
                table: "ContentItems",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "CroppedImage", "HasVideo", "Image", "Type" },
                values: new object[] { "https://s1.vcdn.biz/static/f/333958501/image.jpg/pt/r300x423x4", true, "https://s1.vcdn.biz/static/f/333958501/image.jpg/pt/r300x423x4", "Телеканали" });

            migrationBuilder.UpdateData(
                table: "ContentItems",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "CroppedImage", "HasVideo", "Image", "Type" },
                values: new object[] { "https://s2.vcdn.biz/static/f/4961863001/image.jpg/pt/r300x423x4", true, "https://s2.vcdn.biz/static/f/4961863001/image.jpg/pt/r300x423x4", "Телеканали" });

            migrationBuilder.UpdateData(
                table: "ContentItems",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "CroppedImage", "Image", "Type" },
                values: new object[] { "https://s1.vcdn.biz/static/f/672118741/image.jpg/pt/r300x423x4", "https://s1.vcdn.biz/static/f/672118741/image.jpg/pt/r300x423x4", "Телеканали" });

            migrationBuilder.UpdateData(
                table: "ContentItems",
                keyColumn: "ID",
                keyValue: 11,
                column: "Type",
                value: "Телеканали");

            migrationBuilder.UpdateData(
                table: "ContentItems",
                keyColumn: "ID",
                keyValue: 12,
                column: "HasVideo",
                value: false);

            migrationBuilder.UpdateData(
                table: "ContentItems",
                keyColumn: "ID",
                keyValue: 13,
                column: "HasVideo",
                value: false);

            migrationBuilder.UpdateData(
                table: "ContentItems",
                keyColumn: "ID",
                keyValue: 14,
                column: "HasVideo",
                value: false);

            migrationBuilder.UpdateData(
                table: "ContentItems",
                keyColumn: "ID",
                keyValue: 15,
                column: "HasVideo",
                value: false);

            migrationBuilder.UpdateData(
                table: "ContentItems",
                keyColumn: "ID",
                keyValue: 16,
                column: "HasVideo",
                value: false);

            migrationBuilder.UpdateData(
                table: "ContentItems",
                keyColumn: "ID",
                keyValue: 17,
                columns: new[] { "Category", "Type" },
                values: new object[] { "Розмовні", "Радіостанції" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ContentItems",
                keyColumn: "ID",
                keyValue: 2,
                column: "CroppedImage",
                value: "https://s6.vcdn.biz/static/f/4632098541/image.jpg/pt/r300x423x4");

            migrationBuilder.UpdateData(
                table: "ContentItems",
                keyColumn: "ID",
                keyValue: 3,
                column: "CroppedImage",
                value: "https://s9.vcdn.biz/static/f/5354553681/image.jpg/pt/r300x423x4");

            migrationBuilder.UpdateData(
                table: "ContentItems",
                keyColumn: "ID",
                keyValue: 4,
                column: "CroppedImage",
                value: "https://s9.vcdn.biz/static/f/5354553681/image.jpg/pt/r300x423x4");

            migrationBuilder.UpdateData(
                table: "ContentItems",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CroppedImage", "HasVideo", "Image", "Type" },
                values: new object[] { "https://s1.vcdn.biz/static/f/333958501/image.jpg/pt/r300x423x4", false, "https://s1.vcdn.biz/static/f/333958501/image.jpg/pt/r300x423x4", "Радіостанції" });

            migrationBuilder.UpdateData(
                table: "ContentItems",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "CroppedImage", "HasVideo", "Image", "Type" },
                values: new object[] { "https://s9.vcdn.biz/static/f/5354553681/image.jpg/pt/r300x423x4", false, "https://s2.vcdn.biz/static/f/4961863001/image.jpg/pt/r300x423x4", "Радіостанції" });

            migrationBuilder.UpdateData(
                table: "ContentItems",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "CroppedImage", "HasVideo", "Image", "Type" },
                values: new object[] { "https://s1.vcdn.biz/static/f/672118741/image.jpg/pt/r300x423x4", false, "https://s1.vcdn.biz/static/f/672118741/image.jpg/pt/r300x423x4", "Радіостанції" });

            migrationBuilder.UpdateData(
                table: "ContentItems",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "CroppedImage", "Image", "Type" },
                values: new object[] { "https://s9.vcdn.biz/static/f/5016844881/image.jpg/pt/r300x423x4", "https://s9.vcdn.biz/static/f/5016844881/image.jpg/pt/r300x423x4", "Радіостанції" });

            migrationBuilder.UpdateData(
                table: "ContentItems",
                keyColumn: "ID",
                keyValue: 11,
                column: "Type",
                value: "Радіостанції");

            migrationBuilder.UpdateData(
                table: "ContentItems",
                keyColumn: "ID",
                keyValue: 12,
                column: "HasVideo",
                value: true);

            migrationBuilder.UpdateData(
                table: "ContentItems",
                keyColumn: "ID",
                keyValue: 13,
                column: "HasVideo",
                value: true);

            migrationBuilder.UpdateData(
                table: "ContentItems",
                keyColumn: "ID",
                keyValue: 14,
                column: "HasVideo",
                value: true);

            migrationBuilder.UpdateData(
                table: "ContentItems",
                keyColumn: "ID",
                keyValue: 15,
                column: "HasVideo",
                value: true);

            migrationBuilder.UpdateData(
                table: "ContentItems",
                keyColumn: "ID",
                keyValue: 16,
                column: "HasVideo",
                value: true);

            migrationBuilder.UpdateData(
                table: "ContentItems",
                keyColumn: "ID",
                keyValue: 17,
                columns: new[] { "Category", "Type" },
                values: new object[] { "", "Розмовні" });
        }
    }
}
