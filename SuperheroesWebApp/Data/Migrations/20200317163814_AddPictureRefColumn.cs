using Microsoft.EntityFrameworkCore.Migrations;

namespace SuperheroesWebApp.Data.Migrations
{
    public partial class AddPictureRefColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RefPicture",
                table: "Superhero",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RefPicture",
                table: "Superhero");
        }
    }
}
