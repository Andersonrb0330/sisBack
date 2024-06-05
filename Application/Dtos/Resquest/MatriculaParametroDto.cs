using Domain.Entity;

namespace Application.Dtos.Resquest
{
    public class MatriculaParametroDto
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Estado { get; set; }

        // F_K
        public int IdAlumno { get; set; }
        public int IdLogin { get; set; }

        public MatriculaParametroDto() { }
    }
}
