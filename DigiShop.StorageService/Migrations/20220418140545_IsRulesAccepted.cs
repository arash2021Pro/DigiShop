using Microsoft.EntityFrameworkCore.Migrations;

namespace DigiShop.StorageService.Migrations
{
    public partial class IsRulesAccepted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsRulesAccepted",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRulesAccepted",
                table: "Users");
        }
    }
}
