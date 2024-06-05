namespace Domain.Entity
{
    public class MaestroDetalle
    {
        public int Id { get; set; }
        public int IdMatricula { get; set; }
        public virtual Matricula Matricula { get; set; }
        public int IdCurso { get; set; }
        public virtual Curso Curso { get; set; }
        public int Acreditado { get; set; }
        public string Estado { get; set; }

        public MaestroDetalle() { }
    }

}
