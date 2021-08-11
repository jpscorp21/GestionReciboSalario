using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace GestionReciboSalario.API.Migrations
{
    public partial class recibos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "t_empleado",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre_empleado = table.Column<string>(type: "text", nullable: true),
                    usuario = table.Column<string>(type: "text", nullable: true),
                    password = table.Column<string>(type: "text", nullable: true),
                    rol = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_t_empleado", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "t_recibo_salario",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    empleado_id = table.Column<int>(type: "integer", nullable: false),
                    gerente_id = table.Column<int>(type: "integer", nullable: true),
                    monto_salario = table.Column<double>(type: "double precision", nullable: false),
                    monto_ips = table.Column<double>(type: "double precision", nullable: false),
                    fecha = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    bonificacion_familiar = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_t_recibo_salario", x => x.id);
                    table.ForeignKey(
                        name: "fk_t_recibo_salario_t_empleado_empleado_id",
                        column: x => x.empleado_id,
                        principalTable: "t_empleado",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_t_recibo_salario_t_empleado_gerente_id",
                        column: x => x.gerente_id,
                        principalTable: "t_empleado",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "t_empleado",
                columns: new[] { "id", "nombre_empleado", "password", "rol", "usuario" },
                values: new object[,]
                {
                    { 1, "Luis Alberto del Parana", "secret", 2, "luis" },
                    { 2, "Gabriel Casccia", "secret", 2, "gabriel" },
                    { 3, "Augusto Roa Bastos", "secret", 2, "augusto" },
                    { 4, "Bertha Rojas", "secret", 2, "bertha" },
                    { 5, "Juan Pueblo", "secret", 2, "juan" },
                    { 6, "Francisco Russo", "secret", 2, "francisco" },
                    { 7, "Elvis Presley", "secret", 1, "elvis" }
                });

            migrationBuilder.InsertData(
                table: "t_recibo_salario",
                columns: new[] { "id", "bonificacion_familiar", "empleado_id", "fecha", "gerente_id", "monto_ips", "monto_salario" },
                values: new object[,]
                {
                    { 1, 115000.0, 1, new DateTimeOffset(new DateTime(2021, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -4, 0, 0, 0)), 7, 207000.0, 2300000.0 },
                    { 2, 130000.0, 2, new DateTimeOffset(new DateTime(2021, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -4, 0, 0, 0)), 7, 234000.0, 2600000.0 },
                    { 3, 140000.0, 3, new DateTimeOffset(new DateTime(2021, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -4, 0, 0, 0)), 7, 252000.0, 2800000.0 },
                    { 4, 135000.0, 4, new DateTimeOffset(new DateTime(2021, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -4, 0, 0, 0)), 7, 243000.0, 2700000.0 },
                    { 5, 135000.0, 5, new DateTimeOffset(new DateTime(2021, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -4, 0, 0, 0)), 7, 243000.0, 2700000.0 },
                    { 6, 120000.0, 6, new DateTimeOffset(new DateTime(2021, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -4, 0, 0, 0)), 7, 216000.0, 2400000.0 }
                });

            migrationBuilder.CreateIndex(
                name: "ix_t_recibo_salario_empleado_id",
                table: "t_recibo_salario",
                column: "empleado_id");

            migrationBuilder.CreateIndex(
                name: "ix_t_recibo_salario_gerente_id",
                table: "t_recibo_salario",
                column: "gerente_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "t_recibo_salario");

            migrationBuilder.DropTable(
                name: "t_empleado");
        }
    }
}
