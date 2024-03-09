using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace curriculumManager.src.infrastructure.database.migrations
{
    /// <inheritdoc />
    public partial class insertCustomerEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "varchar", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Photo = table.Column<String>(type: "TEXT", nullable: true),
                    Adress = table.Column<string>(type: "varchar", nullable: true),
                    Neighborhood = table.Column<string>(type: "varchar", nullable: true),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    StateId = table.Column<int>(type: "int", nullable: false),
                    AdressCode = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "varchar", nullable: false),
                    Resume = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "varchar", nullable: false),
                    PhoneNumberOptional = table.Column<string>(type: "varchar", nullable: false),
                    Created_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Deleted_at = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Customers_States_StateId",
                        column: x => x.StateId,
                        principalTable: "State",
                        principalColumn: "Id");
                });

                migrationBuilder.CreateIndex(
                    name: "IX_Customers_CityId",
                    table: "Customer",
                    column: "CityId");

                migrationBuilder.CreateIndex(
                    name: "IX_Customers_StateId",
                    table: "Customer",
                    column: "StateId");
         }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customer");
        }
    }
}
