using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Json.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTableBook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_books_AuthorID",
                table: "books",
                column: "AuthorID");

            migrationBuilder.AddForeignKey(
                name: "FK_books_authors_AuthorID",
                table: "books",
                column: "AuthorID",
                principalTable: "authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_books_authors_AuthorID",
                table: "books");

            migrationBuilder.DropIndex(
                name: "IX_books_AuthorID",
                table: "books");
        }
    }
}
