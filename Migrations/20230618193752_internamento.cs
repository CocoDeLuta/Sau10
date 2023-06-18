using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sau10.Migrations
{
    /// <inheritdoc />
    public partial class internamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FuncionarioId",
                table: "Internamentos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumeroQuarto",
                table: "Internamentos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PacienteId",
                table: "Internamentos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FuncionarioId",
                table: "Internamentos");

            migrationBuilder.DropColumn(
                name: "NumeroQuarto",
                table: "Internamentos");

            migrationBuilder.DropColumn(
                name: "PacienteId",
                table: "Internamentos");
        }
    }
}
