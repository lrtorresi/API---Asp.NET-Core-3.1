using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartSchollAPI.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Matricula = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    DataNascimento = table.Column<DateTime>(nullable: false),
                    Sobrenome = table.Column<string>(nullable: true),
                    Telefone = table.Column<string>(nullable: true),
                    DataInicio = table.Column<DateTime>(nullable: false),
                    DataFim = table.Column<DateTime>(nullable: true),
                    isAtivo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Professores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Registro = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Sobrenome = table.Column<string>(nullable: true),
                    telefone = table.Column<string>(nullable: true),
                    DataInicio = table.Column<DateTime>(nullable: false),
                    DataFim = table.Column<DateTime>(nullable: true),
                    isAtivo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AlunosCursos",
                columns: table => new
                {
                    AlunoId = table.Column<int>(nullable: false),
                    CursoId = table.Column<int>(nullable: false),
                    Datainicio = table.Column<DateTime>(nullable: false),
                    DataFim = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunosCursos", x => new { x.AlunoId, x.CursoId });
                    table.ForeignKey(
                        name: "FK_AlunosCursos_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunosCursos_Cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Cursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Disciplinas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(nullable: true),
                    CargaHoraria = table.Column<int>(nullable: false),
                    PreRequisitoId = table.Column<int>(nullable: true),
                    ProfessorId = table.Column<int>(nullable: false),
                    CursoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplinas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Disciplinas_Cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Cursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Disciplinas_Disciplinas_PreRequisitoId",
                        column: x => x.PreRequisitoId,
                        principalTable: "Disciplinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Disciplinas_Professores_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AlunosDisciplinas",
                columns: table => new
                {
                    AlunoId = table.Column<int>(nullable: false),
                    DisciplinaId = table.Column<int>(nullable: false),
                    DataInicio = table.Column<DateTime>(nullable: false),
                    DataFim = table.Column<DateTime>(nullable: true),
                    Nota = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunosDisciplinas", x => new { x.AlunoId, x.DisciplinaId });
                    table.ForeignKey(
                        name: "FK_AlunosDisciplinas_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunosDisciplinas_Disciplinas_DisciplinaId",
                        column: x => x.DisciplinaId,
                        principalTable: "Disciplinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "DataFim", "DataInicio", "DataNascimento", "Matricula", "Nome", "Sobrenome", "Telefone", "isAtivo" },
                values: new object[] { 1, null, new DateTime(2020, 5, 6, 18, 32, 22, 822, DateTimeKind.Local).AddTicks(6529), new DateTime(2005, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Marta", "Kent", "33225555", true });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "DataFim", "DataInicio", "DataNascimento", "Matricula", "Nome", "Sobrenome", "Telefone", "isAtivo" },
                values: new object[] { 2, null, new DateTime(2020, 5, 6, 18, 32, 22, 822, DateTimeKind.Local).AddTicks(8687), new DateTime(2005, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Paula", "Isabela", "3354288", true });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "DataFim", "DataInicio", "DataNascimento", "Matricula", "Nome", "Sobrenome", "Telefone", "isAtivo" },
                values: new object[] { 3, null, new DateTime(2020, 5, 6, 18, 32, 22, 822, DateTimeKind.Local).AddTicks(8736), new DateTime(2005, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Laura", "Antonia", "55668899", true });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "DataFim", "DataInicio", "DataNascimento", "Matricula", "Nome", "Sobrenome", "Telefone", "isAtivo" },
                values: new object[] { 4, null, new DateTime(2020, 5, 6, 18, 32, 22, 822, DateTimeKind.Local).AddTicks(8742), new DateTime(2005, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Luiza", "Maria", "6565659", true });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "DataFim", "DataInicio", "DataNascimento", "Matricula", "Nome", "Sobrenome", "Telefone", "isAtivo" },
                values: new object[] { 5, null, new DateTime(2020, 5, 6, 18, 32, 22, 822, DateTimeKind.Local).AddTicks(8747), new DateTime(2005, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Lucas", "Machado", "565685415", true });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "DataFim", "DataInicio", "DataNascimento", "Matricula", "Nome", "Sobrenome", "Telefone", "isAtivo" },
                values: new object[] { 6, null, new DateTime(2020, 5, 6, 18, 32, 22, 822, DateTimeKind.Local).AddTicks(8754), new DateTime(2005, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "Pedro", "Alvares", "456454545", true });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "DataFim", "DataInicio", "DataNascimento", "Matricula", "Nome", "Sobrenome", "Telefone", "isAtivo" },
                values: new object[] { 7, null, new DateTime(2020, 5, 6, 18, 32, 22, 822, DateTimeKind.Local).AddTicks(8758), new DateTime(2005, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, "Paulo", "José", "9874512", true });

            migrationBuilder.InsertData(
                table: "Cursos",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 1, "Tecnologia da Informação" });

            migrationBuilder.InsertData(
                table: "Cursos",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 2, "Sistemas de Informação" });

            migrationBuilder.InsertData(
                table: "Cursos",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 3, "Ciência da Computação" });

            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "Id", "DataFim", "DataInicio", "Nome", "Registro", "Sobrenome", "isAtivo", "telefone" },
                values: new object[] { 1, null, new DateTime(2020, 5, 6, 18, 32, 22, 818, DateTimeKind.Local).AddTicks(4884), "Lauro", 1, "Oliveira", true, null });

            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "Id", "DataFim", "DataInicio", "Nome", "Registro", "Sobrenome", "isAtivo", "telefone" },
                values: new object[] { 2, null, new DateTime(2020, 5, 6, 18, 32, 22, 819, DateTimeKind.Local).AddTicks(3886), "Roberto", 2, "Soares", true, null });

            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "Id", "DataFim", "DataInicio", "Nome", "Registro", "Sobrenome", "isAtivo", "telefone" },
                values: new object[] { 3, null, new DateTime(2020, 5, 6, 18, 32, 22, 819, DateTimeKind.Local).AddTicks(4074), "Ronaldo", 3, "Marconi", true, null });

            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "Id", "DataFim", "DataInicio", "Nome", "Registro", "Sobrenome", "isAtivo", "telefone" },
                values: new object[] { 4, null, new DateTime(2020, 5, 6, 18, 32, 22, 819, DateTimeKind.Local).AddTicks(4077), "Rodrigo", 4, "Carvalho", true, null });

            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "Id", "DataFim", "DataInicio", "Nome", "Registro", "Sobrenome", "isAtivo", "telefone" },
                values: new object[] { 5, null, new DateTime(2020, 5, 6, 18, 32, 22, 819, DateTimeKind.Local).AddTicks(4078), "Alexandre", 5, "Montanha", true, null });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CargaHoraria", "CursoId", "Nome", "PreRequisitoId", "ProfessorId" },
                values: new object[] { 1, 0, 1, "Matemática", null, 1 });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CargaHoraria", "CursoId", "Nome", "PreRequisitoId", "ProfessorId" },
                values: new object[] { 2, 0, 3, "Matemática", null, 1 });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CargaHoraria", "CursoId", "Nome", "PreRequisitoId", "ProfessorId" },
                values: new object[] { 3, 0, 3, "Física", null, 2 });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CargaHoraria", "CursoId", "Nome", "PreRequisitoId", "ProfessorId" },
                values: new object[] { 4, 0, 1, "Português", null, 3 });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CargaHoraria", "CursoId", "Nome", "PreRequisitoId", "ProfessorId" },
                values: new object[] { 5, 0, 1, "Inglês", null, 4 });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CargaHoraria", "CursoId", "Nome", "PreRequisitoId", "ProfessorId" },
                values: new object[] { 6, 0, 2, "Inglês", null, 4 });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CargaHoraria", "CursoId", "Nome", "PreRequisitoId", "ProfessorId" },
                values: new object[] { 7, 0, 3, "Inglês", null, 4 });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CargaHoraria", "CursoId", "Nome", "PreRequisitoId", "ProfessorId" },
                values: new object[] { 8, 0, 1, "Programação", null, 5 });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CargaHoraria", "CursoId", "Nome", "PreRequisitoId", "ProfessorId" },
                values: new object[] { 9, 0, 2, "Programação", null, 5 });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CargaHoraria", "CursoId", "Nome", "PreRequisitoId", "ProfessorId" },
                values: new object[] { 10, 0, 3, "Programação", null, 5 });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataInicio", "Nota" },
                values: new object[] { 2, 1, null, new DateTime(2020, 5, 6, 18, 32, 22, 823, DateTimeKind.Local).AddTicks(506), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataInicio", "Nota" },
                values: new object[] { 4, 5, null, new DateTime(2020, 5, 6, 18, 32, 22, 823, DateTimeKind.Local).AddTicks(519), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataInicio", "Nota" },
                values: new object[] { 2, 5, null, new DateTime(2020, 5, 6, 18, 32, 22, 823, DateTimeKind.Local).AddTicks(511), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataInicio", "Nota" },
                values: new object[] { 1, 5, null, new DateTime(2020, 5, 6, 18, 32, 22, 823, DateTimeKind.Local).AddTicks(505), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataInicio", "Nota" },
                values: new object[] { 7, 4, null, new DateTime(2020, 5, 6, 18, 32, 22, 823, DateTimeKind.Local).AddTicks(532), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataInicio", "Nota" },
                values: new object[] { 6, 4, null, new DateTime(2020, 5, 6, 18, 32, 22, 823, DateTimeKind.Local).AddTicks(527), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataInicio", "Nota" },
                values: new object[] { 5, 4, null, new DateTime(2020, 5, 6, 18, 32, 22, 823, DateTimeKind.Local).AddTicks(520), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataInicio", "Nota" },
                values: new object[] { 4, 4, null, new DateTime(2020, 5, 6, 18, 32, 22, 823, DateTimeKind.Local).AddTicks(518), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataInicio", "Nota" },
                values: new object[] { 1, 4, null, new DateTime(2020, 5, 6, 18, 32, 22, 823, DateTimeKind.Local).AddTicks(480), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataInicio", "Nota" },
                values: new object[] { 7, 3, null, new DateTime(2020, 5, 6, 18, 32, 22, 823, DateTimeKind.Local).AddTicks(531), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataInicio", "Nota" },
                values: new object[] { 5, 5, null, new DateTime(2020, 5, 6, 18, 32, 22, 823, DateTimeKind.Local).AddTicks(522), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataInicio", "Nota" },
                values: new object[] { 6, 3, null, new DateTime(2020, 5, 6, 18, 32, 22, 823, DateTimeKind.Local).AddTicks(525), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataInicio", "Nota" },
                values: new object[] { 7, 2, null, new DateTime(2020, 5, 6, 18, 32, 22, 823, DateTimeKind.Local).AddTicks(529), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataInicio", "Nota" },
                values: new object[] { 6, 2, null, new DateTime(2020, 5, 6, 18, 32, 22, 823, DateTimeKind.Local).AddTicks(524), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataInicio", "Nota" },
                values: new object[] { 3, 2, null, new DateTime(2020, 5, 6, 18, 32, 22, 823, DateTimeKind.Local).AddTicks(513), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataInicio", "Nota" },
                values: new object[] { 2, 2, null, new DateTime(2020, 5, 6, 18, 32, 22, 823, DateTimeKind.Local).AddTicks(507), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataInicio", "Nota" },
                values: new object[] { 1, 2, null, new DateTime(2020, 5, 6, 18, 32, 22, 822, DateTimeKind.Local).AddTicks(9789), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataInicio", "Nota" },
                values: new object[] { 7, 1, null, new DateTime(2020, 5, 6, 18, 32, 22, 823, DateTimeKind.Local).AddTicks(528), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataInicio", "Nota" },
                values: new object[] { 6, 1, null, new DateTime(2020, 5, 6, 18, 32, 22, 823, DateTimeKind.Local).AddTicks(523), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataInicio", "Nota" },
                values: new object[] { 4, 1, null, new DateTime(2020, 5, 6, 18, 32, 22, 823, DateTimeKind.Local).AddTicks(517), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataInicio", "Nota" },
                values: new object[] { 3, 1, null, new DateTime(2020, 5, 6, 18, 32, 22, 823, DateTimeKind.Local).AddTicks(512), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataInicio", "Nota" },
                values: new object[] { 3, 3, null, new DateTime(2020, 5, 6, 18, 32, 22, 823, DateTimeKind.Local).AddTicks(514), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataInicio", "Nota" },
                values: new object[] { 7, 5, null, new DateTime(2020, 5, 6, 18, 32, 22, 823, DateTimeKind.Local).AddTicks(533), null });

            migrationBuilder.CreateIndex(
                name: "IX_AlunosCursos_CursoId",
                table: "AlunosCursos",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_AlunosDisciplinas_DisciplinaId",
                table: "AlunosDisciplinas",
                column: "DisciplinaId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplinas_CursoId",
                table: "Disciplinas",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplinas_PreRequisitoId",
                table: "Disciplinas",
                column: "PreRequisitoId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplinas_ProfessorId",
                table: "Disciplinas",
                column: "ProfessorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlunosCursos");

            migrationBuilder.DropTable(
                name: "AlunosDisciplinas");

            migrationBuilder.DropTable(
                name: "Alunos");

            migrationBuilder.DropTable(
                name: "Disciplinas");

            migrationBuilder.DropTable(
                name: "Cursos");

            migrationBuilder.DropTable(
                name: "Professores");
        }
    }
}
