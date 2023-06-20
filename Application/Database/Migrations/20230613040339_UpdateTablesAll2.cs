using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Json.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTablesAll2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_authors_libraries_LibraryId",
                table: "authors");

            migrationBuilder.DropForeignKey(
                name: "FK_books_libraries_LibraryId",
                table: "books");

            migrationBuilder.DropIndex(
                name: "IX_books_LibraryId",
                table: "books");

            migrationBuilder.DropIndex(
                name: "IX_authors_LibraryId",
                table: "authors");

            migrationBuilder.DropColumn(
                name: "LibraryId",
                table: "books");

            migrationBuilder.DropColumn(
                name: "LibraryId",
                table: "authors");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LibraryId",
                table: "books",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LibraryId",
                table: "authors",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_books_LibraryId",
                table: "books",
                column: "LibraryId");

            migrationBuilder.CreateIndex(
                name: "IX_authors_LibraryId",
                table: "authors",
                column: "LibraryId");

            migrationBuilder.AddForeignKey(
                name: "FK_authors_libraries_LibraryId",
                table: "authors",
                column: "LibraryId",
                principalTable: "libraries",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_books_libraries_LibraryId",
                table: "books",
                column: "LibraryId",
                principalTable: "libraries",
                principalColumn: "Id");
        }
    }
}
