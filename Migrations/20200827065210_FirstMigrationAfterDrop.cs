using Microsoft.EntityFrameworkCore.Migrations;

namespace Virtual_Car_Show_Project.Migrations
{
    public partial class FirstMigrationAfterDrop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(45) CHARACTER SET utf8mb4",
                oldMaxLength: 45);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "varchar(45) CHARACTER SET utf8mb4",
                maxLength: 45,
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
