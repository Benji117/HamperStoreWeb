using Microsoft.EntityFrameworkCore.Migrations;

namespace HamperStoreWeb.Migrations
{
    public partial class EditedDataAnnotationProductCodeProductsTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductCOde",
                table: "Products",
                newName: "ProductCode");

            migrationBuilder.AlterColumn<string>(
                name: "ProductCode",
                table: "Products",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(int),
                oldMaxLength: 10);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductCode",
                table: "Products",
                newName: "ProductCOde");

            migrationBuilder.AlterColumn<int>(
                name: "ProductCOde",
                table: "Products",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 10);
        }
    }
}
