using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Json.Migrations
{
    /// <inheritdoc />
    public partial class CreateTable_Librari : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "libraries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AuthorID = table.Column<int>(type: "int", nullable: false),
                    BookID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_libraries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_libraries_authors_AuthorID",
                        column: x => x.AuthorID,
                        principalTable: "authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_libraries_books_BookID",
                        column: x => x.BookID,
                        principalTable: "books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_books_LibraryId",
                table: "books",
                column: "LibraryId");

            migrationBuilder.CreateIndex(
                name: "IX_authors_LibraryId",
                table: "authors",
                column: "LibraryId");

            migrationBuilder.CreateIndex(
                name: "IX_libraries_AuthorID",
                table: "libraries",
                column: "AuthorID");

            migrationBuilder.CreateIndex(
                name: "IX_libraries_BookID",
                table: "libraries",
                column: "BookID");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_authors_libraries_LibraryId",
                table: "authors");

            migrationBuilder.DropForeignKey(
                name: "FK_books_libraries_LibraryId",
                table: "books");

            migrationBuilder.DropTable(
                name: "libraries");

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
    }
}
