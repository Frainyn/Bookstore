using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Json.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTablesAll : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_libraries_authors_AuthorID",
                table: "libraries");

            migrationBuilder.DropForeignKey(
                name: "FK_libraries_books_BookID",
                table: "libraries");

            migrationBuilder.RenameColumn(
                name: "BookID",
                table: "libraries",
                newName: "BookId");

            migrationBuilder.RenameColumn(
                name: "AuthorID",
                table: "libraries",
                newName: "AuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_libraries_BookID",
                table: "libraries",
                newName: "IX_libraries_BookId");

            migrationBuilder.RenameIndex(
                name: "IX_libraries_AuthorID",
                table: "libraries",
                newName: "IX_libraries_AuthorId");

            migrationBuilder.AddColumn<int>(
                name: "Book",
                table: "authors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_libraries_authors_AuthorId",
                table: "libraries",
                column: "AuthorId",
                principalTable: "authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_libraries_books_BookId",
                table: "libraries",
                column: "BookId",
                principalTable: "books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_libraries_authors_AuthorId",
                table: "libraries");

            migrationBuilder.DropForeignKey(
                name: "FK_libraries_books_BookId",
                table: "libraries");

            migrationBuilder.DropColumn(
                name: "Book",
                table: "authors");

            migrationBuilder.RenameColumn(
                name: "BookId",
                table: "libraries",
                newName: "BookID");

            migrationBuilder.RenameColumn(
                name: "AuthorId",
                table: "libraries",
                newName: "AuthorID");

            migrationBuilder.RenameIndex(
                name: "IX_libraries_BookId",
                table: "libraries",
                newName: "IX_libraries_BookID");

            migrationBuilder.RenameIndex(
                name: "IX_libraries_AuthorId",
                table: "libraries",
                newName: "IX_libraries_AuthorID");

            migrationBuilder.AddForeignKey(
                name: "FK_libraries_authors_AuthorID",
                table: "libraries",
                column: "AuthorID",
                principalTable: "authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
