using Microsoft.EntityFrameworkCore.Migrations;

namespace HamperStoreWeb.Migrations
{
    public partial class AddedFKOnHamperTblForHamperCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HamperCategories_Hampers_HamperId",
                table: "HamperCategories");

            migrationBuilder.DropIndex(
                name: "IX_HamperCategories_HamperId",
                table: "HamperCategories");

            migrationBuilder.AddColumn<int>(
                name: "HamperCategoryId",
                table: "Hampers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HamperCategoryId1",
                table: "Hampers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hampers_HamperCategoryId1",
                table: "Hampers",
                column: "HamperCategoryId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Hampers_HamperCategories_HamperCategoryId1",
                table: "Hampers",
                column: "HamperCategoryId1",
                principalTable: "HamperCategories",
                principalColumn: "HamperCategoryId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hampers_HamperCategories_HamperCategoryId1",
                table: "Hampers");

            migrationBuilder.DropIndex(
                name: "IX_Hampers_HamperCategoryId1",
                table: "Hampers");

            migrationBuilder.DropColumn(
                name: "HamperCategoryId",
                table: "Hampers");

            migrationBuilder.DropColumn(
                name: "HamperCategoryId1",
                table: "Hampers");

            migrationBuilder.CreateIndex(
                name: "IX_HamperCategories_HamperId",
                table: "HamperCategories",
                column: "HamperId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_HamperCategories_Hampers_HamperId",
                table: "HamperCategories",
                column: "HamperId",
                principalTable: "Hampers",
                principalColumn: "HamperId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
