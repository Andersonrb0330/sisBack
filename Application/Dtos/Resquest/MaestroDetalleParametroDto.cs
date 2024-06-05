namespace Application.Dtos.Resquest
{
    public class MaestroDetalleParametroDto
    {
        public int Id { get; set; }
        public int IdMatricula { get; set; }
        public int IdCurso { get; set; }
        public int Acreditado { get; set; }
        public string Estado { get; set; }

        public MaestroDetalleParametroDto() { }
    }
}
