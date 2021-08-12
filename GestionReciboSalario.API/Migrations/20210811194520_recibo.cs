using Microsoft.EntityFrameworkCore.Migrations;

namespace GestionReciboSalario.API.Migrations
{
    public partial class recibo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "firma_empleado",
                table: "t_recibo_salario",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "firma_gerente",
                table: "t_recibo_salario",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "firma_url",
                table: "t_recibo_salario",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "firma_empleado",
                table: "t_recibo_salario");

            migrationBuilder.DropColumn(
                name: "firma_gerente",
                table: "t_recibo_salario");

            migrationBuilder.DropColumn(
                name: "firma_url",
                table: "t_recibo_salario");
        }
    }
}
