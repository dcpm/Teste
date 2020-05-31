using Microsoft.EntityFrameworkCore.Migrations;

namespace EscolaASC_WebAPI.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Materias",
                columns: table => new
                {
                    Materiaid = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nome = table.Column<string>(nullable: true),
                    peso1 = table.Column<int>(nullable: false),
                    peso2 = table.Column<int>(nullable: false),
                    peso3 = table.Column<int>(nullable: false),
                    media = table.Column<int>(nullable: false),
                    situacao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materias", x => x.Materiaid);
                });

            migrationBuilder.CreateTable(
                name: "Prova",
                columns: table => new
                {
                    Provaid = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Materiaid = table.Column<int>(nullable: true),
                    prova1 = table.Column<int>(nullable: false),
                    prova2 = table.Column<int>(nullable: false),
                    prova3 = table.Column<int>(nullable: false),
                    provaFinal = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prova", x => x.Provaid);
                    table.ForeignKey(
                        name: "FK_Prova_Materias_Materiaid",
                        column: x => x.Materiaid,
                        principalTable: "Materias",
                        principalColumn: "Materiaid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prova_Materiaid",
                table: "Prova",
                column: "Materiaid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prova");

            migrationBuilder.DropTable(
                name: "Materias");
        }
    }
}
