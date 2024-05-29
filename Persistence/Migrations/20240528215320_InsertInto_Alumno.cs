using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InsertInto_Alumno : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Inserta datos en la tabla Alumno
            migrationBuilder.Sql("INSERT INTO Alumno (Nombres, Apellidos, Telefono, Edad, IdAula, IdCategoria) VALUES ('Lil Anderson', 'Briceño Leon', '123456789', 20, 3, 3)");
            migrationBuilder.Sql("INSERT INTO Alumno (Nombres, Apellidos, Telefono, Edad, IdAula, IdCategoria) VALUES ('Kure Brayan', 'Rios Polo', '987654321', 22, 1, 4)");
        }
    }
}
