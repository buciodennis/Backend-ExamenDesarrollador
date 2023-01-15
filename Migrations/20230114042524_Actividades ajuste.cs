using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Migrations
{
    public partial class Actividadesajuste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actividades",
                columns: table => new
                {
                    idActividad = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    actividad = table.Column<string>(type: "nvarchar(40)", nullable: true),
                    descripcion = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    idUsuario = table.Column<int>(type: "int", nullable: false),
                    usuarioidUsuario = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actividades", x => x.idActividad);
                    table.ForeignKey(
                        name: "FK_Actividades_Usuarios_usuarioidUsuario",
                        column: x => x.usuarioidUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "idUsuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Actividades_usuarioidUsuario",
                table: "Actividades",
                column: "usuarioidUsuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Actividades");
        }
    }
}
