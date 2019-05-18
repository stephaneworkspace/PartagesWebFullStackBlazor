using Microsoft.EntityFrameworkCore.Migrations;

namespace PartagesWebBlazorFSCore3.Server.Migrations
{
    public partial class FixNameInForumCategorieMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nom",
                table: "ForumCategories",
                newName: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "ForumCategories",
                newName: "Nom");
        }
    }
}
