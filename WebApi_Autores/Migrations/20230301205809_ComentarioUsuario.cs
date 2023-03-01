using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi_Autores.Migrations
{
    /// <inheritdoc />
    public partial class ComentarioUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UsuarioId1",
                table: "Comentarios",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuuarioId",
                table: "Comentarios",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_UsuuarioId",
                table: "Comentarios",
                column: "UsuuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comentarios_AspNetUsers_UsuuarioId",
                table: "Comentarios",
                column: "UsuuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comentarios_AspNetUsers_UsuuarioId",
                table: "Comentarios");

            migrationBuilder.DropIndex(
                name: "IX_Comentarios_UsuuarioId",
                table: "Comentarios");

            migrationBuilder.DropColumn(
                name: "UsuarioId1",
                table: "Comentarios");

            migrationBuilder.DropColumn(
                name: "UsuuarioId",
                table: "Comentarios");
        }
    }
}
