namespace Domain.Entity
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public ICollection<Alumno>  Alumnos{ get; set; }

        public Categoria() { }
    }
}
