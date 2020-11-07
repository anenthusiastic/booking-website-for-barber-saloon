using Microsoft.EntityFrameworkCore.Migrations;

namespace data.Migrations
{
    public partial class mg7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropTable(
                name: "Barbers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Bookings");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Bookings",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "barberId",
                table: "Bookings",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Barbers",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    imageUrl = table.Column<string>(type: "TEXT", nullable: true),
                    name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Barbers", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_barberId",
                table: "Bookings",
                column: "barberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Barbers_barberId",
                table: "Bookings",
                column: "barberId",
                principalTable: "Barbers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
