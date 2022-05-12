using Microsoft.EntityFrameworkCore.Migrations;

namespace DigiShop.StorageService.Migrations
{
    public partial class SiteSettings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SiteSettings",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailPassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SiteDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SiteKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SiteName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SmsApi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SmsSender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModificationTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteSettings", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SiteSettings");
        }
    }
}
