using Domain.Entity;

namespace Domain.IRepositories
{
    public interface ILoginRepository
    {
        Task<List<Login>> Get();
        Task<Login> GetById(int id);
        Task Create(Login login);
        void Delete(Login login);
        Task<bool> VerificarEmail(string email);
        Task<Login> LoginInfo(string email, string password);
        Task<bool> verificarLogin(int id);
    }
}
