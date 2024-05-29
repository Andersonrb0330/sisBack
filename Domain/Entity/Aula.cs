namespace Domain.Entity
{
    public class Aula
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public ICollection<Alumno> Alumnos { get; set; }

        public Aula () { }
    }
}
