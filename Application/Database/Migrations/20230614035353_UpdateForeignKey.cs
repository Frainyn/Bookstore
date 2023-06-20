using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Json.Migrations
{
    /// <inheritdoc />
    public partial class UpdateForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_libraries_books_BookID",
                table: "libraries");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_books_Id1C",
                table: "books",
                column: "Id1C");

            migrationBuilder.AddForeignKey(
                name: "FK_libraries_books_BookID",
                table: "libraries",
                column: "BookID",
                principalTable: "books",
                principalColumn: "Id1C",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_libraries_books_BookID",
                table: "libraries");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_books_Id1C",
                table: "books");

            migrationBuilder.AddForeignKey(
                name: "FK_libraries_books_BookID",
                table: "libraries",
                column: "BookID",
                principalTable: "books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
