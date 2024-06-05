namespace Domain.Entity
{
    public class Matricula
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Estado { get; set; }

        // F_K
        public int IdAlumno { get; set; }
        public virtual Alumno Alumno { get; set; }
        public int IdLogin { get; set; }
        public virtual Login Login { get; set; }

        public ICollection<MaestroDetalle> MaestroDetalles { get; set; }

        public Matricula() { }
    }
}
