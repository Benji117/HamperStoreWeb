using Microsoft.EntityFrameworkCore.Migrations;

namespace HamperStoreWeb.Migrations
{
    public partial class AddedProductDescriptionFieldToProductTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Productdescription",
                table: "Products",
                maxLength: 200,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Productdescription",
                table: "Products");
        }
    }
}
