using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LTPR.Migrations
{
    public partial class addedbasket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblBasket");
        }
    }
}
