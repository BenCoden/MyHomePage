using Microsoft.EntityFrameworkCore.Migrations;

namespace MyHomePage.Migrations
{
    public partial class updateLink : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Links",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(nullable: false),
                    IsTheSearchSite = table.Column<bool>(nullable: false),
                    IsPined = table.Column<bool>(nullable: false),
                    CanSearchSite = table.Column<bool>(nullable: false),
                    Text = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    InvertImageColors = table.Column<bool>(nullable: false),
                    BackgroundColor = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Links", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SearchProviders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DisplayName = table.Column<string>(nullable: true),
                    SearchUrl = table.Column<string>(nullable: true),
                    IsDefault = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SearchProviders", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Links");

            migrationBuilder.DropTable(
                name: "SearchProviders");
        }
    }
}
