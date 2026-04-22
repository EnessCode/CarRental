using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRental.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Add_RentACarProcess_NewColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReservationId",
                table: "RentACarProcesses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "RentACarProcesses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_RentACarProcesses_ReservationId",
                table: "RentACarProcesses",
                column: "ReservationId");

            migrationBuilder.AddForeignKey(
                name: "FK_RentACarProcesses_Reservations_ReservationId",
                table: "RentACarProcesses",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RentACarProcesses_Reservations_ReservationId",
                table: "RentACarProcesses");

            migrationBuilder.DropIndex(
                name: "IX_RentACarProcesses_ReservationId",
                table: "RentACarProcesses");

            migrationBuilder.DropColumn(
                name: "ReservationId",
                table: "RentACarProcesses");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "RentACarProcesses");
        }
    }
}
