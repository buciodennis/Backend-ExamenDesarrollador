using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Migrations
{
    public partial class Actividades : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ubicaciones",
                columns: table => new
                {
                    idUbicacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    calle = table.Column<string>(type: "nvarchar(25)", nullable: true),
                    numero = table.Column<int>(type: "int", nullable: false),
                    colonia = table.Column<string>(type: "nvarchar(25)", nullable: true),
                    cp = table.Column<int>(type: "int", nullable: false),
                    ciudad = table.Column<string>(type: "nvarchar(25)", nullable: true),
                    estado = table.Column<string>(type: "nvarchar(25)", nullable: true),
                    pais = table.Column<string>(type: "nvarchar(25)", nullable: true),
                    eliminado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ubicaciones", x => x.idUbicacion);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    idUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(35)", nullable: true),
                    eliminado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.idUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    idClientes = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(35)", nullable: true),
                    idUbicacion = table.Column<int>(type: "int", nullable: false),
                    ubicacionidUbicacion = table.Column<int>(type: "int", nullable: true),
                    eliminado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.idClientes);
                    table.ForeignKey(
                        name: "FK_Clientes_Ubicaciones_ubicacionidUbicacion",
                        column: x => x.ubicacionidUbicacion,
                        principalTable: "Ubicaciones",
                        principalColumn: "idUbicacion",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Contactos",
                columns: table => new
                {
                    idContacto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(35)", nullable: true),
                    telefono = table.Column<string>(type: "nvarchar(15)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(40)", nullable: true),
                    sitio = table.Column<string>(type: "nvarchar(25)", nullable: true),
                    idUbicacion = table.Column<int>(type: "int", nullable: false),
                    eliminado = table.Column<bool>(type: "bit", nullable: false),
                    UbicacionidUbicacion = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contactos", x => x.idContacto);
                    table.ForeignKey(
                        name: "FK_Contactos_Ubicaciones_UbicacionidUbicacion",
                        column: x => x.UbicacionidUbicacion,
                        principalTable: "Ubicaciones",
                        principalColumn: "idUbicacion",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Credenciales",
                columns: table => new
                {
                    idCredencial = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(type: "nvarchar(40)", nullable: true),
                    contrasenia = table.Column<string>(type: "nvarchar(70)", nullable: true),
                    eliminado = table.Column<bool>(type: "bit", nullable: false),
                    tipo = table.Column<int>(type: "int", nullable: false),
                    idUsuario = table.Column<int>(type: "int", nullable: false),
                    idCliente = table.Column<int>(type: "int", nullable: false),
                    usuarioidUsuario = table.Column<int>(type: "int", nullable: true),
                    clienteidClientes = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Credenciales", x => x.idCredencial);
                    table.ForeignKey(
                        name: "FK_Credenciales_Clientes_clienteidClientes",
                        column: x => x.clienteidClientes,
                        principalTable: "Clientes",
                        principalColumn: "idClientes",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Credenciales_Usuarios_usuarioidUsuario",
                        column: x => x.usuarioidUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "idUsuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_ubicacionidUbicacion",
                table: "Clientes",
                column: "ubicacionidUbicacion");

            migrationBuilder.CreateIndex(
                name: "IX_Contactos_UbicacionidUbicacion",
                table: "Contactos",
                column: "UbicacionidUbicacion");

            migrationBuilder.CreateIndex(
                name: "IX_Credenciales_clienteidClientes",
                table: "Credenciales",
                column: "clienteidClientes");

            migrationBuilder.CreateIndex(
                name: "IX_Credenciales_usuarioidUsuario",
                table: "Credenciales",
                column: "usuarioidUsuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contactos");

            migrationBuilder.DropTable(
                name: "Credenciales");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Ubicaciones");
        }
    }
}
