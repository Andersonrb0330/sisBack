using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InsertInto_Matricula : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Matricula (Fecha, Estado, IdAlumno, IdLogin) VALUES ('1-1-2024', 'Activo',40, 1)");
        }
    }
}
