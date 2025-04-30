using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppDotacion.Migrations
{
    /// <inheritdoc />
    public partial class NombreDeLaMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dotaciones",
                columns: table => new
                {
                    ID = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rut_DNI = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Agente = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Pais_Call_Center = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Nombre_Call_Center = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Area = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    AreaGestion = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Contrato = table.Column<byte>(type: "tinyint", nullable: true),
                    Tipos_de_agente = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Servicio = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Usuarios_RcWeb = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Nombre_Jefatura = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Rut_Ficticio = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Rut_DNI2 = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    DV = table.Column<byte>(type: "tinyint", nullable: true),
                    Clasifica_Cargo = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    CARGO = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Fecha_Ingreso = table.Column<int>(type: "int", nullable: true),
                    Fecha_Baja = table.Column<int>(type: "int", nullable: true),
                    N_Personal = table.Column<int>(type: "int", nullable: true),
                    Correo = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Cliente = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Region = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Provincia = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Comuna = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Segmento = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    SubSegmento = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    TipoServicio = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Proyecto = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Instalacion = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Supervisor = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    EstadoServicio = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    EstadoInstalacion = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    EstadoCliente = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dotaciones", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dotaciones");
        }
    }
}
