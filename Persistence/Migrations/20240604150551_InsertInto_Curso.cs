using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InsertInto_Curso : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Curso (Nombre, Descripcion) VALUES ('Matematica', 'Ciencia que estudia las relaciones entre cantidades')");
            migrationBuilder.Sql("INSERT INTO Curso (Nombre, Descripcion) VALUES ('Historia', 'Estudiar los eventos del pasado de la humanidad')");
            migrationBuilder.Sql("INSERT INTO Curso (Nombre, Descripcion) VALUES ('Quimica', 'Ciencia que estudia la materia, la energía y sus cambios')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
