using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LTPR.Migrations
{
    public partial class addDiscountCodes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblDiscountCodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblMenuAtRestaurant",
                table: "tblMenuAtRestaurant");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblItemOnMenu",
                table: "tblItemOnMenu");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblIngredientInItem",
                table: "tblIngredientInItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblImageOnMenuItem",
                table: "tblImageOnMenuItem");

            migrationBuilder.DropColumn(
                name: "Retired",
                table: "tblMenuItem");

            migrationBuilder.DropColumn(
                name: "SpecialDay",
                table: "tblItemOnMenu");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MenuAtRestaurant",
                table: "tblMenuAtRestaurant",
                columns: new[] { "RID", "MID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemOnMenu",
                table: "tblItemOnMenu",
                columns: new[] { "MID", "IID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_IngredientInItem",
                table: "tblIngredientInItem",
                columns: new[] { "IID", "MIID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImageOnMenuItem",
                table: "tblImageOnMenuItem",
                columns: new[] { "IID", "MIID" });
        }
    }
}
