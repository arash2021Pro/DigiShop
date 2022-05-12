using Microsoft.EntityFrameworkCore.Migrations;

namespace DigiShop.StorageService.Migrations
{
    public partial class icon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "icon",
                table: "StoreCategories",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "icon",
                table: "StoreCategories");
        }
    }
}
