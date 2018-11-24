using Microsoft.EntityFrameworkCore.Migrations;

namespace HamperStoreWeb.Migrations
{
    public partial class UpdatedHamperCategoryNameToString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "HamperCategoryName",
                table: "HamperCategories",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "HamperCategoryName",
                table: "HamperCategories",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
