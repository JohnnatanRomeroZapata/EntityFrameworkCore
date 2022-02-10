using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCoreDataAccess.Migrations
{
    public partial class AddOneToOneFluentBookFluentBookDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FluentBookDetailId",
                table: "FluentBooks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_FluentBooks_FluentBookDetailId",
                table: "FluentBooks",
                column: "FluentBookDetailId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FluentBooks_FluentBookDetails_FluentBookDetailId",
                table: "FluentBooks",
                column: "FluentBookDetailId",
                principalTable: "FluentBookDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FluentBooks_FluentBookDetails_FluentBookDetailId",
                table: "FluentBooks");

            migrationBuilder.DropIndex(
                name: "IX_FluentBooks_FluentBookDetailId",
                table: "FluentBooks");

            migrationBuilder.DropColumn(
                name: "FluentBookDetailId",
                table: "FluentBooks");
        }
    }
}
