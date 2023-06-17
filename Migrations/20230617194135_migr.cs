using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sau10.Migrations
{
    /// <inheritdoc />
    public partial class migr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConsultaFuncionario");

            migrationBuilder.AddColumn<int>(
                name: "FuncionarioId",
                table: "Consultas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Consultas_FuncionarioId",
                table: "Consultas",
                column: "FuncionarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultas_Funcionarios_FuncionarioId",
                table: "Consultas",
                column: "FuncionarioId",
                principalTable: "Funcionarios",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consultas_Funcionarios_FuncionarioId",
                table: "Consultas");

            migrationBuilder.DropIndex(
                name: "IX_Consultas_FuncionarioId",
                table: "Consultas");

            migrationBuilder.DropColumn(
                name: "FuncionarioId",
                table: "Consultas");

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
                name: "IX_ConsultaFuncionario_FuncionariosId",
                table: "ConsultaFuncionario",
                column: "FuncionariosId");
        }
    }
}
