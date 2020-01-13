using Microsoft.EntityFrameworkCore.Migrations;

namespace MyHomePage.EntityFrameworkCoreSQL.Migrations
{
    public partial class updateLink8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "CanSearchSite",
                table: "Links",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Links",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPined",
                table: "Links",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsTheSearchSite",
                table: "Links",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CanSearchSite",
                table: "Links");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Links");

            migrationBuilder.DropColumn(
                name: "IsPined",
                table: "Links");

            migrationBuilder.DropColumn(
                name: "IsTheSearchSite",
                table: "Links");
        }
    }
}
