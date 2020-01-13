using Microsoft.EntityFrameworkCore.Migrations;

namespace MyHomePage.EntityFrameworkCoreSQL.Migrations
{
    public partial class updatePined : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPined",
                table: "Links");

            migrationBuilder.DropColumn(
                name: "IsTheSearchSite",
                table: "Links");

            migrationBuilder.AddColumn<int>(
                name: "Pined",
                table: "Links",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pined",
                table: "Links");

            migrationBuilder.AddColumn<bool>(
                name: "IsPined",
                table: "Links",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsTheSearchSite",
                table: "Links",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
