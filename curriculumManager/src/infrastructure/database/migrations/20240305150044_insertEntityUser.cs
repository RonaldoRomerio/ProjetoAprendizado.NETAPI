using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace curriculumManager.src.infrastructe.database.migrations
{
    /// <inheritdoc />
    public partial class insertEntityUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "VARCHAR", nullable: false),
                    Password = table.Column<string>(type: "VARCHAR", nullable: false),
                    Roles = table.Column<int>(type: "VARCHAR", nullable: false),
                    Status = table.Column<bool>(type: "INTEGER", nullable: false),
                    Created_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Deleted_at = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
