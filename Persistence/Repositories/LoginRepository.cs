using Domain.Entity;
using Domain.IRepositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private readonly ISisContext _sisContext;

        public LoginRepository(ISisContext sisContext)
        {
            _sisContext = sisContext;
        }

        public async Task<List<Login>> Get()
        {
            List<Login> login = await _sisContext.Logins.ToListAsync();
            return login;
        }

        public async Task<Login> GetById(int id)
        {
            Login login = await _sisContext.Logins.FirstOrDefaultAsync(u => u.Id == id);
            return login;
        }

        public async Task Create(Login login)
        {
            await _sisContext.Logins.AddAsync(login);
        }

        public void Delete(Login login)
        {
            _sisContext.Logins.Remove(login);
            _sisContext.SaveChanges();
        }
        public async Task<bool> VerificarEmail(string email)
        {
            bool existeEmail = await _sisContext.Logins
                 .AnyAsync(u => u.Email == email);
            return existeEmail;
        }

        public async Task<Login> LoginInfo(string email, string password)
        {
            Login login = await _sisContext.Logins
                .FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
            return login;
        }

        public async Task<bool> verificarLogin(int id)
        {
            bool verificarLogin = await _sisContext.Logins.AnyAsync(l => l.Id == id);
            return verificarLogin;
        }
    }
}
