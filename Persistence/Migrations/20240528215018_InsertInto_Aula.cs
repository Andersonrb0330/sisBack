using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InsertInto_Aula : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Inserta datos en la tabla Aula
            migrationBuilder.Sql("INSERT INTO Aula (Nombre) VALUES ('Sección A')");
            migrationBuilder.Sql("INSERT INTO Aula (Nombre) VALUES ('Sección B')");
            migrationBuilder.Sql("INSERT INTO Aula (Nombre) VALUES ('Sección C')");
            migrationBuilder.Sql("INSERT INTO Aula (Nombre) VALUES ('Sección D')");
            migrationBuilder.Sql("INSERT INTO Aula (Nombre) VALUES ('Sección E')");
        }
    }
}
