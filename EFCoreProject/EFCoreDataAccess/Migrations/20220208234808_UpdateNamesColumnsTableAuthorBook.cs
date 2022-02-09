using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCoreDataAccess.Migrations
{
    public partial class UpdateNamesColumnsTableAuthorBook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthorBook_Authors_AuthorListId",
                table: "AuthorBook");

            migrationBuilder.DropForeignKey(
                name: "FK_AuthorBook_Books_BookListId",
                table: "AuthorBook");

            migrationBuilder.RenameColumn(
                name: "BookListId",
                table: "AuthorBook",
                newName: "BookIdId");

            migrationBuilder.RenameColumn(
                name: "AuthorListId",
                table: "AuthorBook",
                newName: "AuthorIdId");

            migrationBuilder.RenameIndex(
                name: "IX_AuthorBook_BookListId",
                table: "AuthorBook",
                newName: "IX_AuthorBook_BookIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorBook_Authors_AuthorIdId",
                table: "AuthorBook",
                column: "AuthorIdId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorBook_Books_BookIdId",
                table: "AuthorBook",
                column: "BookIdId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthorBook_Authors_AuthorIdId",
                table: "AuthorBook");

            migrationBuilder.DropForeignKey(
                name: "FK_AuthorBook_Books_BookIdId",
                table: "AuthorBook");

            migrationBuilder.RenameColumn(
                name: "BookIdId",
                table: "AuthorBook",
                newName: "BookListId");

            migrationBuilder.RenameColumn(
                name: "AuthorIdId",
                table: "AuthorBook",
                newName: "AuthorListId");

            migrationBuilder.RenameIndex(
                name: "IX_AuthorBook_BookIdId",
                table: "AuthorBook",
                newName: "IX_AuthorBook_BookListId");

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorBook_Authors_AuthorListId",
                table: "AuthorBook",
                column: "AuthorListId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorBook_Books_BookListId",
                table: "AuthorBook",
                column: "BookListId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
