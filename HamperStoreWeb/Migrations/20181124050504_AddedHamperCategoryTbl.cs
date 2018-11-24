using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HamperStoreWeb.Migrations
{
    public partial class AddedHamperCategoryTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HamperCategories",
                columns: table => new
                {
                    HamperCategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    HamperCategoryName = table.Column<int>(nullable: false),
                    Discontinued = table.Column<bool>(nullable: false),
                    HamperId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HamperCategories", x => x.HamperCategoryId);
                    table.ForeignKey(
                        name: "FK_HamperCategories_Hampers_HamperId",
                        column: x => x.HamperId,
                        principalTable: "Hampers",
                        principalColumn: "HamperId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HamperCategories_HamperId",
                table: "HamperCategories",
                column: "HamperId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HamperCategories");
        }
    }
}
