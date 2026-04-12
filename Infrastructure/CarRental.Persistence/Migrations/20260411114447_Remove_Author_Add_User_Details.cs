using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRental.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Remove_Author_Add_User_Details : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_Authors_AuthorId",
                table: "Blogs");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.RenameColumn(
                name: "AuthorId",
                table: "Blogs",
                newName: "AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Blogs_AuthorId",
                table: "Blogs",
                newName: "IX_Blogs_AppUserId");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "AppUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "AppUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_AppUsers_AppUserId",
                table: "Blogs",
                column: "AppUserId",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_AppUsers_AppUserId",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "AppUsers");

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "Blogs",
                newName: "AuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_Blogs_AppUserId",
                table: "Blogs",
                newName: "IX_Blogs_AuthorId");

            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_Authors_AuthorId",
                table: "Blogs",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
