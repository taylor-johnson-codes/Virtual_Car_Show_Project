using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Virtual_Car_Show_Project.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "State",
                table: "Users",
                maxLength: 2,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                maxLength: 45,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                maxLength: 45,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Users",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Users",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Users",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Cars",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "CarShowToAttendCarShowId",
                table: "Cars",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CarShows",
                columns: table => new
                {
                    CarShowId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(maxLength: 30, nullable: false),
                    ClubName = table.Column<string>(maxLength: 30, nullable: false),
                    StartDateAndTime = table.Column<DateTime>(nullable: false),
                    EndDateAndTime = table.Column<DateTime>(nullable: false),
                    StreetAddress = table.Column<string>(maxLength: 30, nullable: false),
                    City = table.Column<string>(maxLength: 30, nullable: false),
                    State = table.Column<string>(maxLength: 2, nullable: false),
                    ZipCode = table.Column<string>(maxLength: 5, nullable: false),
                    Description = table.Column<string>(maxLength: 100, nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarShows", x => x.CarShowId);
                    table.ForeignKey(
                        name: "FK_CarShows_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CarShowToAttendCarShowId",
                table: "Cars",
                column: "CarShowToAttendCarShowId");

            migrationBuilder.CreateIndex(
                name: "IX_CarShows_UserId",
                table: "CarShows",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_CarShows_CarShowToAttendCarShowId",
                table: "Cars",
                column: "CarShowToAttendCarShowId",
                principalTable: "CarShows",
                principalColumn: "CarShowId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_CarShows_CarShowToAttendCarShowId",
                table: "Cars");

            migrationBuilder.DropTable(
                name: "CarShows");

            migrationBuilder.DropIndex(
                name: "IX_Cars_CarShowToAttendCarShowId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CarShowToAttendCarShowId",
                table: "Cars");

            migrationBuilder.AlterColumn<string>(
                name: "State",
                table: "Users",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 2);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 45);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 45);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Users",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 30);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Users",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Cars",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);
        }
    }
}
