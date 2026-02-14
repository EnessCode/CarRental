using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRental.Persistence.Migrations
{
	/// <inheritdoc />
	public partial class Fix_CarPricing_Amount : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.RenameColumn(
				name: "Amounth",
				table: "CarPricings",
				newName: "Amount");
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.RenameColumn(
				name: "Amount",
				table: "CarPricings",
				newName: "Amounth");
		}
	}
}
