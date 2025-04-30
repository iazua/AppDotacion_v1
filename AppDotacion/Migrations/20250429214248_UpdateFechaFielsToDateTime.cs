using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppDotacion.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFechaFielsToDateTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cliente",
                table: "Dotaciones");

            migrationBuilder.DropColumn(
                name: "Comuna",
                table: "Dotaciones");

            migrationBuilder.DropColumn(
                name: "EstadoCliente",
                table: "Dotaciones");

            migrationBuilder.DropColumn(
                name: "EstadoInstalacion",
                table: "Dotaciones");

            migrationBuilder.DropColumn(
                name: "EstadoServicio",
                table: "Dotaciones");

            migrationBuilder.DropColumn(
                name: "Instalacion",
                table: "Dotaciones");

            migrationBuilder.DropColumn(
                name: "Provincia",
                table: "Dotaciones");

            migrationBuilder.DropColumn(
                name: "Proyecto",
                table: "Dotaciones");

            migrationBuilder.DropColumn(
                name: "Region",
                table: "Dotaciones");

            migrationBuilder.DropColumn(
                name: "Segmento",
                table: "Dotaciones");

            migrationBuilder.DropColumn(
                name: "SubSegmento",
                table: "Dotaciones");

            migrationBuilder.DropColumn(
                name: "Supervisor",
                table: "Dotaciones");

            migrationBuilder.DropColumn(
                name: "TipoServicio",
                table: "Dotaciones");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cliente",
                table: "Dotaciones",
                type: "nvarchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Comuna",
                table: "Dotaciones",
                type: "nvarchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EstadoCliente",
                table: "Dotaciones",
                type: "nvarchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EstadoInstalacion",
                table: "Dotaciones",
                type: "nvarchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EstadoServicio",
                table: "Dotaciones",
                type: "nvarchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Instalacion",
                table: "Dotaciones",
                type: "nvarchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Provincia",
                table: "Dotaciones",
                type: "nvarchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Proyecto",
                table: "Dotaciones",
                type: "nvarchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Region",
                table: "Dotaciones",
                type: "nvarchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Segmento",
                table: "Dotaciones",
                type: "nvarchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubSegmento",
                table: "Dotaciones",
                type: "nvarchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Supervisor",
                table: "Dotaciones",
                type: "nvarchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TipoServicio",
                table: "Dotaciones",
                type: "nvarchar(100)",
                nullable: true);
        }
    }
}
