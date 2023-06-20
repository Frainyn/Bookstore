using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Json.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTablesAll4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_libraries_authors_AuthorId",
                table: "libraries");

            migrationBuilder.DropForeignKey(
                name: "FK_libraries_books_BookId",
                table: "libraries");

            migrationBuilder.DropTable(
                name: "AuthorBook");

            migrationBuilder.DropColumn(
                name: "Author",
                table: "books");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "Author",
                table: "books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Book",
                table: "authors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AuthorBook",
                columns: table => new
                {
                    AuthorsId = table.Column<int>(type: "int", nullable: false),
                    BooksId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorBook", x => new { x.AuthorsId, x.BooksId });
                    table.ForeignKey(
                        name: "FK_AuthorBook_authors_AuthorsId",
                        column: x => x.AuthorsId,
                        principalTable: "authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthorBook_books_BooksId",
                        column: x => x.BooksId,
                        principalTable: "books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_AuthorBook_BooksId",
                table: "AuthorBook",
                column: "BooksId");

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
    }
}
