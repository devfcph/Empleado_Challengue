using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Empleado_Prueba.Migrations
{
    /// <inheritdoc />
    public partial class new_version : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EmpleadosDataSet",
                table: "EmpleadosDataSet");

            migrationBuilder.RenameTable(
                name: "EmpleadosDataSet",
                newName: "Empleado");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Empleado",
                table: "Empleado",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Empleado",
                table: "Empleado");

            migrationBuilder.RenameTable(
                name: "Empleado",
                newName: "EmpleadosDataSet");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmpleadosDataSet",
                table: "EmpleadosDataSet",
                column: "Id");
        }
    }
}
