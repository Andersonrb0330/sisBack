namespace Application.Dtos.Resquest
{
    public class FiltroMatriculaParametroDto : PaginacionParametroDto
    {
        public DateTime? Fecha { get; set; }
        public string Estado { get; set; }

        // F_K
        public int? IdAlumno { get; set; }
        public int? IdLogin { get; set; }

        public FiltroMatriculaParametroDto() { }
    }
}
