namespace Domain.Entity
{
    public class Login
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public ICollection<Matricula> Matriculas { get; set; }
        public Login() { } }
}
