using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCoreDataAccess.Migrations
{
    public partial class AddInformationToCategoryTableWithMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Categories VALUES('Category1')");
            migrationBuilder.Sql("INSERT INTO Categories VALUES('Category2')");
            migrationBuilder.Sql("INSERT INTO Categories VALUES('Category3')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
