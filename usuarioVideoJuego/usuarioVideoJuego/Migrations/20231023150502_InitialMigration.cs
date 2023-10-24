using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace usuarioVideoJuego.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "usuario",
                columns: table => new
                {
                    Id_Usuario = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Genero = table.Column<string>(type: "text", nullable: false),
                    Edad = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario", x => x.Id_Usuario);
                });

            migrationBuilder.CreateTable(
                name: "email",
                columns: table => new
                {
                    Id_Email = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Id_Usuario = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_email", x => x.Id_Email);
                    table.ForeignKey(
                        name: "FK_email_usuario_Id_Usuario",
                        column: x => x.Id_Usuario,
                        principalTable: "usuario",
                        principalColumn: "Id_Usuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "videoJuegos",
                columns: table => new
                {
                    Id_VideoJuego = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    tipoDePgo = table.Column<string>(type: "text", nullable: false),
                    esGrupal = table.Column<string>(type: "text", nullable: false),
                    tipo = table.Column<bool>(type: "boolean", nullable: false),
                    Id_Usuario = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_videoJuegos", x => x.Id_VideoJuego);
                    table.ForeignKey(
                        name: "FK_videoJuegos_usuario_Id_Usuario",
                        column: x => x.Id_Usuario,
                        principalTable: "usuario",
                        principalColumn: "Id_Usuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_email_Id_Usuario",
                table: "email",
                column: "Id_Usuario");

            migrationBuilder.CreateIndex(
                name: "IX_videoJuegos_Id_Usuario",
                table: "videoJuegos",
                column: "Id_Usuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "email");

            migrationBuilder.DropTable(
                name: "videoJuegos");

            migrationBuilder.DropTable(
                name: "usuario");
        }
    }
}
