using Microsoft.EntityFrameworkCore.Migrations;

namespace data.Migrations
{
    public partial class mg2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "barberId",
                table: "Bookings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Barber",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Barber", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_barberId",
                table: "Bookings",
                column: "barberId");


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Barber_barberId",
                table: "Bookings");

            migrationBuilder.DropTable(
                name: "Barber");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_barberId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "barberId",
                table: "Bookings");
        }
    }
}
