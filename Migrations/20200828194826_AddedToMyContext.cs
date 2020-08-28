using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Virtual_Car_Show_Project.Migrations
{
    public partial class AddedToMyContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RegisteredCars",
                columns: table => new
                {
                    RegisteredCarsId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    CarShowId = table.Column<int>(nullable: false),
                    CarId = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegisteredCars", x => x.RegisteredCarsId);
                    table.ForeignKey(
                        name: "FK_RegisteredCars_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "CarId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RegisteredCars_CarShows_CarShowId",
                        column: x => x.CarShowId,
                        principalTable: "CarShows",
                        principalColumn: "CarShowId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RegisteredCars_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RegisteredCars_CarId",
                table: "RegisteredCars",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_RegisteredCars_CarShowId",
                table: "RegisteredCars",
                column: "CarShowId");

            migrationBuilder.CreateIndex(
                name: "IX_RegisteredCars_UserId",
                table: "RegisteredCars",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RegisteredCars");
        }
    }
}
