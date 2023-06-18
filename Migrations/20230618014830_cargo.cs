using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sau10.Migrations
{
    /// <inheritdoc />
    public partial class cargo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consultas_Funcionarios_FuncionarioId",
                table: "Consultas");

            migrationBuilder.DropForeignKey(
                name: "FK_Consultas_Pacientes_PacienteId",
                table: "Consultas");

            migrationBuilder.DropForeignKey(
                name: "FK_Internamentos_Pacientes_PacienteId",
                table: "Internamentos");

            migrationBuilder.DropIndex(
                name: "IX_Internamentos_PacienteId",
                table: "Internamentos");

            migrationBuilder.DropIndex(
                name: "IX_Consultas_PacienteId",
                table: "Consultas");

            migrationBuilder.DropColumn(
                name: "PacienteId",
                table: "Internamentos");

            migrationBuilder.RenameColumn(
                name: "data",
                table: "Consultas",
                newName: "Data");

            migrationBuilder.AlterColumn<int>(
                name: "PacienteId",
                table: "Consultas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FuncionarioId",
                table: "Consultas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Cargos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargos", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultas_Funcionarios_FuncionarioId",
                table: "Consultas",
                column: "FuncionarioId",
                principalTable: "Funcionarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consultas_Funcionarios_FuncionarioId",
                table: "Consultas");

            migrationBuilder.DropTable(
                name: "Cargos");

            migrationBuilder.RenameColumn(
                name: "Data",
                table: "Consultas",
                newName: "data");

            migrationBuilder.AddColumn<int>(
                name: "PacienteId",
                table: "Internamentos",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PacienteId",
                table: "Consultas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "FuncionarioId",
                table: "Consultas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Internamentos_PacienteId",
                table: "Internamentos",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Consultas_PacienteId",
                table: "Consultas",
                column: "PacienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultas_Funcionarios_FuncionarioId",
                table: "Consultas",
                column: "FuncionarioId",
                principalTable: "Funcionarios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultas_Pacientes_PacienteId",
                table: "Consultas",
                column: "PacienteId",
                principalTable: "Pacientes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Internamentos_Pacientes_PacienteId",
                table: "Internamentos",
                column: "PacienteId",
                principalTable: "Pacientes",
                principalColumn: "Id");
        }
    }
}
