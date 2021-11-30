using Microsoft.EntityFrameworkCore.Migrations;

namespace mvc.Migrations
{
    public partial class DatabaseMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Humidity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataHora = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    UmidTemp = table.Column<float>(type: "float(5)", nullable: false),
                    Umidade = table.Column<float>(type: "float(5)", nullable: false),
                    UR = table.Column<float>(type: "float(5)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Humidity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Wind",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataHora = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    Velocidade = table.Column<float>(type: "float(10)", nullable: false),
                    Direcao = table.Column<float>(type: "float(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wind", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Station",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    Local = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    Temperatura = table.Column<float>(type: "float(5)", nullable: false),
                    VentoId = table.Column<int>(type: "int", nullable: true),
                    UmidadeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Station", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Station_Humidity_UmidadeId",
                        column: x => x.UmidadeId,
                        principalTable: "Humidity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Station_Wind_VentoId",
                        column: x => x.VentoId,
                        principalTable: "Wind",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Station_UmidadeId",
                table: "Station",
                column: "UmidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Station_VentoId",
                table: "Station",
                column: "VentoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Station");

            migrationBuilder.DropTable(
                name: "Humidity");

            migrationBuilder.DropTable(
                name: "Wind");
        }
    }
}
