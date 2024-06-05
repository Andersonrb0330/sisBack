namespace Domain.Entity
{
    public class Curso
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public ICollection<MaestroDetalle> MaestroDetalles { get; set; }

        public Curso() { }
    }
}
