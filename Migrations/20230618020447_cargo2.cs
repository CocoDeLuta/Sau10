using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sau10.Migrations
{
    /// <inheritdoc />
    public partial class cargo2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consultas_Funcionarios_FuncionarioId",
                table: "Consultas");

            migrationBuilder.DropForeignKey(
                name: "FK_Internamentos_Funcionarios_FuncionarioId",
                table: "Internamentos");

            migrationBuilder.DropIndex(
                name: "IX_Internamentos_FuncionarioId",
                table: "Internamentos");

            migrationBuilder.DropIndex(
                name: "IX_Consultas_FuncionarioId",
                table: "Consultas");

            migrationBuilder.DropColumn(
                name: "FuncionarioId",
                table: "Internamentos");

            migrationBuilder.DropColumn(
                name: "Cargo",
                table: "Funcionarios");

            migrationBuilder.AddColumn<int>(
                name: "CargoId",
                table: "Funcionarios",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CargoId",
                table: "Funcionarios");

            migrationBuilder.AddColumn<int>(
                name: "FuncionarioId",
                table: "Internamentos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cargo",
                table: "Funcionarios",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Internamentos_FuncionarioId",
                table: "Internamentos",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Consultas_FuncionarioId",
                table: "Consultas",
                column: "FuncionarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultas_Funcionarios_FuncionarioId",
                table: "Consultas",
                column: "FuncionarioId",
                principalTable: "Funcionarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Internamentos_Funcionarios_FuncionarioId",
                table: "Internamentos",
                column: "FuncionarioId",
                principalTable: "Funcionarios",
                principalColumn: "Id");
        }
    }
}
