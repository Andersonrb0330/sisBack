using Domain.Entity;

namespace Application.Dtos.Resquest
{
    public class FiltroMaestroDetalleParametroDto : PaginacionParametroDto
    {
        public int? IdMatricula { get; set; }
        public int? IdCurso { get; set; }
        public int Acreditado { get; set; }
        public string Estado { get; set; }
    }
}
