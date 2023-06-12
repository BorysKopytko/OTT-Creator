using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OTTCreator.WebApp.Migrations
{
    /// <inheritdoc />
    public partial class IntialCreate101 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ContentItems",
                keyColumn: "ID",
                keyValue: 1,
                column: "CroppedImage",
                value: "https://s9.vcdn.biz/static/f/5354553681/image.jpg/pt/r300x423x4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ContentItems",
                keyColumn: "ID",
                keyValue: 1,
                column: "CroppedImage",
                value: "https://www.photos-public-domain.com/wp-content/uploads/2016/08/tortie-cat-300x300.jpg");
        }
    }
}
