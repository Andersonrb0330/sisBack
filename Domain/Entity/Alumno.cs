namespace Domain.Entity
{
    public class Alumno
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Telefono { get; set; }
        public int Edad { get; set; }

        // F_k
        public int IdAula { get; set; }
        public virtual Aula Aula { get; set; }

        public int IdCategoria { get; set; }
        public virtual Categoria Categoria { get; set; }

        public Alumno () { }
    }
}
