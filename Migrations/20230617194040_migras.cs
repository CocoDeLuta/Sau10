using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sau10.Migrations
{
    /// <inheritdoc />
    public partial class migras : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Funcionarios_Consultas_ConsultaId",
                table: "Funcionarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Funcionarios_Internamentos_InternamentoId",
                table: "Funcionarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Pacientes_Internamentos_InternamentoId",
                table: "Pacientes");

            migrationBuilder.DropIndex(
                name: "IX_Pacientes_InternamentoId",
                table: "Pacientes");

            migrationBuilder.DropIndex(
                name: "IX_Funcionarios_ConsultaId",
                table: "Funcionarios");

            migrationBuilder.DropIndex(
                name: "IX_Funcionarios_InternamentoId",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "InternamentoId",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "ConsultaId",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "InternamentoId",
                table: "Funcionarios");

            migrationBuilder.AddColumn<int>(
                name: "FuncionarioId",
                table: "Internamentos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PacienteId",
                table: "Internamentos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PacienteId",
                table: "Consultas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ConsultaFuncionario",
                columns: table => new
                {
                    ConsultasId = table.Column<int>(type: "int", nullable: false),
                    FuncionariosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsultaFuncionario", x => new { x.ConsultasId, x.FuncionariosId });
                    table.ForeignKey(
                        name: "FK_ConsultaFuncionario_Consultas_ConsultasId",
                        column: x => x.ConsultasId,
                        principalTable: "Consultas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConsultaFuncionario_Funcionarios_FuncionariosId",
                        column: x => x.FuncionariosId,
                        principalTable: "Funcionarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Internamentos_FuncionarioId",
                table: "Internamentos",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Internamentos_PacienteId",
                table: "Internamentos",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Consultas_PacienteId",
                table: "Consultas",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsultaFuncionario_FuncionariosId",
                table: "ConsultaFuncionario",
                column: "FuncionariosId");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultas_Pacientes_PacienteId",
                table: "Consultas",
                column: "PacienteId",
                principalTable: "Pacientes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Internamentos_Funcionarios_FuncionarioId",
                table: "Internamentos",
                column: "FuncionarioId",
                principalTable: "Funcionarios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Internamentos_Pacientes_PacienteId",
                table: "Internamentos",
                column: "PacienteId",
                principalTable: "Pacientes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consultas_Pacientes_PacienteId",
                table: "Consultas");

            migrationBuilder.DropForeignKey(
                name: "FK_Internamentos_Funcionarios_FuncionarioId",
                table: "Internamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Internamentos_Pacientes_PacienteId",
                table: "Internamentos");

            migrationBuilder.DropTable(
                name: "ConsultaFuncionario");

            migrationBuilder.DropIndex(
                name: "IX_Internamentos_FuncionarioId",
                table: "Internamentos");

            migrationBuilder.DropIndex(
                name: "IX_Internamentos_PacienteId",
                table: "Internamentos");

            migrationBuilder.DropIndex(
                name: "IX_Consultas_PacienteId",
                table: "Consultas");

            migrationBuilder.DropColumn(
                name: "FuncionarioId",
                table: "Internamentos");

            migrationBuilder.DropColumn(
                name: "PacienteId",
                table: "Internamentos");

            migrationBuilder.DropColumn(
                name: "PacienteId",
                table: "Consultas");

            migrationBuilder.AddColumn<int>(
                name: "InternamentoId",
                table: "Pacientes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ConsultaId",
                table: "Funcionarios",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InternamentoId",
                table: "Funcionarios",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_InternamentoId",
                table: "Pacientes",
                column: "InternamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_ConsultaId",
                table: "Funcionarios",
                column: "ConsultaId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_InternamentoId",
                table: "Funcionarios",
                column: "InternamentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionarios_Consultas_ConsultaId",
                table: "Funcionarios",
                column: "ConsultaId",
                principalTable: "Consultas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionarios_Internamentos_InternamentoId",
                table: "Funcionarios",
                column: "InternamentoId",
                principalTable: "Internamentos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pacientes_Internamentos_InternamentoId",
                table: "Pacientes",
                column: "InternamentoId",
                principalTable: "Internamentos",
                principalColumn: "Id");
        }
    }
}
