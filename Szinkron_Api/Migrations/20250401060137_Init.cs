using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Szinkron_Api.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "film",
                columns: table => new
                {
                    filmaz = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    cim = table.Column<string>(type: "TEXT", nullable: false),
                    eredeti = table.Column<string>(type: "TEXT", nullable: false),
                    ev = table.Column<int>(type: "INTEGER", nullable: false),
                    rendezo = table.Column<string>(type: "TEXT", nullable: false),
                    magyarszoveg = table.Column<string>(type: "TEXT", nullable: false),
                    szinkronrendezo = table.Column<string>(type: "TEXT", nullable: false),
                    studio = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_film", x => x.filmaz);
                });

            migrationBuilder.CreateTable(
                name: "szinkron",
                columns: table => new
                {
                    szinkid = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    filmaz = table.Column<int>(type: "INTEGER", nullable: false),
                    szerep = table.Column<string>(type: "TEXT", nullable: false),
                    szinesz = table.Column<string>(type: "TEXT", nullable: false),
                    hang = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_szinkron", x => x.szinkid);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "film");

            migrationBuilder.DropTable(
                name: "szinkron");
        }
    }
}
