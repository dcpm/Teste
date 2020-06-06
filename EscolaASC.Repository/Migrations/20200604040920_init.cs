using Microsoft.EntityFrameworkCore.Migrations;

namespace EscolaASC.Repository.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    Alunoid = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeAluno = table.Column<string>(nullable: true),
                    Situacao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.Alunoid);
                });

            migrationBuilder.CreateTable(
                name: "Periodos",
                columns: table => new
                {
                    Periodoid = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomePeriodo = table.Column<string>(nullable: true),
                    QuantidadeTurmas = table.Column<int>(nullable: false),
                    QuantidadeAlunos = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Periodos", x => x.Periodoid);
                });

            migrationBuilder.CreateTable(
                name: "Materias",
                columns: table => new
                {
                    Materiaid = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeMateria = table.Column<string>(nullable: true),
                    Periodoid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materias", x => x.Materiaid);
                    table.ForeignKey(
                        name: "FK_Materias_Periodos_Periodoid",
                        column: x => x.Periodoid,
                        principalTable: "Periodos",
                        principalColumn: "Periodoid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Turmas",
                columns: table => new
                {
                    Turmaid = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeTurma = table.Column<string>(nullable: true),
                    Materiaid = table.Column<int>(nullable: true),
                    QuantidadeAluno = table.Column<int>(nullable: false),
                    Periodoid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turmas", x => x.Turmaid);
                    table.ForeignKey(
                        name: "FK_Turmas_Materias_Materiaid",
                        column: x => x.Materiaid,
                        principalTable: "Materias",
                        principalColumn: "Materiaid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Turmas_Periodos_Periodoid",
                        column: x => x.Periodoid,
                        principalTable: "Periodos",
                        principalColumn: "Periodoid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TurmaAluno",
                columns: table => new
                {
                    Turmaid = table.Column<int>(nullable: false),
                    Alunoid = table.Column<int>(nullable: false),
                    Media = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TurmaAluno", x => new { x.Turmaid, x.Alunoid });
                    table.ForeignKey(
                        name: "FK_TurmaAluno_Alunos_Alunoid",
                        column: x => x.Alunoid,
                        principalTable: "Alunos",
                        principalColumn: "Alunoid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TurmaAluno_Turmas_Turmaid",
                        column: x => x.Turmaid,
                        principalTable: "Turmas",
                        principalColumn: "Turmaid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prova",
                columns: table => new
                {
                    Provaid = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nota = table.Column<decimal>(nullable: false),
                    OrdemProva = table.Column<int>(nullable: false),
                    Peso = table.Column<int>(nullable: false),
                    TurmaAlunoAlunoid = table.Column<int>(nullable: true),
                    TurmaAlunoTurmaid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prova", x => x.Provaid);
                    table.ForeignKey(
                        name: "FK_Prova_TurmaAluno_TurmaAlunoTurmaid_TurmaAlunoAlunoid",
                        columns: x => new { x.TurmaAlunoTurmaid, x.TurmaAlunoAlunoid },
                        principalTable: "TurmaAluno",
                        principalColumns: new[] { "Turmaid", "Alunoid" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Materias_Periodoid",
                table: "Materias",
                column: "Periodoid");

            migrationBuilder.CreateIndex(
                name: "IX_Prova_TurmaAlunoTurmaid_TurmaAlunoAlunoid",
                table: "Prova",
                columns: new[] { "TurmaAlunoTurmaid", "TurmaAlunoAlunoid" });

            migrationBuilder.CreateIndex(
                name: "IX_TurmaAluno_Alunoid",
                table: "TurmaAluno",
                column: "Alunoid");

            migrationBuilder.CreateIndex(
                name: "IX_Turmas_Materiaid",
                table: "Turmas",
                column: "Materiaid");

            migrationBuilder.CreateIndex(
                name: "IX_Turmas_Periodoid",
                table: "Turmas",
                column: "Periodoid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prova");

            migrationBuilder.DropTable(
                name: "TurmaAluno");

            migrationBuilder.DropTable(
                name: "Alunos");

            migrationBuilder.DropTable(
                name: "Turmas");

            migrationBuilder.DropTable(
                name: "Materias");

            migrationBuilder.DropTable(
                name: "Periodos");
        }
    }
}
