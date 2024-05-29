using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InsertInto_Categoria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Inserta datos en la tabla Categoria
            migrationBuilder.Sql("INSERT INTO Categoria (Nombre) VALUES ('Primer Año')");
            migrationBuilder.Sql("INSERT INTO Categoria (Nombre) VALUES ('Segundo Año')");
            migrationBuilder.Sql("INSERT INTO Categoria (Nombre) VALUES ('Tercer Año')");
            migrationBuilder.Sql("INSERT INTO Categoria (Nombre) VALUES ('Cuarto Año')");
            migrationBuilder.Sql("INSERT INTO Categoria (Nombre) VALUES ('Quinto Año')");

        }
        
    }
}
