using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LTPR.Migrations
{
    public partial class updateTblSales : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discount",
                table: "tblSales");
        }
    }
}
