using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace curriculumManager.src.infrastructure.database.migrations
{
    /// <inheritdoc />
    public partial class insertForeignKeyAndNewColumnCity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StateId",
                table: "City",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_City_StateId",
                table: "City",
                column: "StateId");

            migrationBuilder.AddForeignKey(
                name: "FK_City_State_StateId",
                table: "City",
                column: "StateId",
                principalTable: "State",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_City_State_StateId",
                table: "City");

            migrationBuilder.DropIndex(
                name: "IX_City_StateId",
                table: "City");

            migrationBuilder.DropColumn(
                name: "StateId",
                table: "City");
        }
    }
}
