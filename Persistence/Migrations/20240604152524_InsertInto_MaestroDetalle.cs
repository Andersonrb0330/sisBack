using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InsertInto_MaestroDetalle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO MaestroDetalle (IdMatricula, IdCurso, Acreditado, Estado) VALUES (6,2,2,'Activo')");
        }
    }
}
