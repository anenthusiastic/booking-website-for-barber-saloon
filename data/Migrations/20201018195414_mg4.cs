using Microsoft.EntityFrameworkCore.Migrations;

namespace data.Migrations
{
    public partial class mg4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.AddColumn<string>(
                name: "imageUrl",
                table: "Services",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "url",
                table: "Categories",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "imageUrl",
                table: "Barbers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
       {

            migrationBuilder.DropColumn(
                name: "imageUrl",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "url",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "imageUrl",
                table: "Barbers");

        }
    }
}
