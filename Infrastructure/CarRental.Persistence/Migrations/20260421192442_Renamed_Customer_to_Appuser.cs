using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRental.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Renamed_Customer_to_Appuser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RentACarProcesses_Customer_CustomerId",
                table: "RentACarProcesses");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "RentACarProcesses",
                newName: "AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_RentACarProcesses_CustomerId",
                table: "RentACarProcesses",
                newName: "IX_RentACarProcesses_AppUserId");

            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "Reservations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_AppUserId",
                table: "Reservations",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_RentACarProcesses_AppUsers_AppUserId",
                table: "RentACarProcesses",
                column: "AppUserId",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_AppUsers_AppUserId",
                table: "Reservations",
                column: "AppUserId",
                principalTable: "AppUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RentACarProcesses_AppUsers_AppUserId",
                table: "RentACarProcesses");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_AppUsers_AppUserId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_AppUserId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Reservations");

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "RentACarProcesses",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_RentACarProcesses_AppUserId",
                table: "RentACarProcesses",
                newName: "IX_RentACarProcesses_CustomerId");

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_RentACarProcesses_Customer_CustomerId",
                table: "RentACarProcesses",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
