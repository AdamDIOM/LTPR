using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LTPR.Migrations
{
    public partial class updatedAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
        }
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LangLat",
                table: "tblRestaurants");

            migrationBuilder.RenameColumn(
                name: "IID",
                table: "tblItemsOnSale",
                newName: "PID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "tblItemsOnSale",
                newName: "IOSID");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "tblMenuAtRestaurant",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "tblItemOnMenu",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "tblIngredientInItem",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "tblImageOnMenuItem",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");
        }
    }
}
