using Microsoft.EntityFrameworkCore.Migrations;

namespace Virtual_Car_Show_Project.Migrations
{
    public partial class AddedFeeToCarShow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Fee",
                table: "CarShows",
                type: "decimal(18, 2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fee",
                table: "CarShows");
        }
    }
}
