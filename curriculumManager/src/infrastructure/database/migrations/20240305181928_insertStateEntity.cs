using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace curriculumManager.src.infrastructure.database.migrations
{
    /// <inheritdoc />
    public partial class insertStateEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "State",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "VARCHAR", nullable: false),
                    Acronym = table.Column<string>(type: "VARCHAR(2)", nullable: false),
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
                name: "State");
        }
    }
}
