using Domain.Entity;
using Domain.IRepositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class AulaRepository : IAulaRepository
    {
        private readonly SisContext _sisContext;

        public AulaRepository(
            SisContext sisContext) 
        {
            _sisContext = sisContext;
        }

        public async Task<List<Aula>> GetAll()
        {
            List<Aula> listAula = await _sisContext.Aulas.ToListAsync();
            return listAula;
        }

        public async Task<Aula> GetById(int id)
        {
            Aula aula = await _sisContext.Aulas.FirstOrDefaultAsync(a => a.Id == id);
            return aula;
        }

        public async Task Create(Aula aula)
        {
            await _sisContext.Aulas.AddAsync(aula);
        }

        public void Delete(Aula aula)
        {
            _sisContext.Aulas.Remove(aula);
        }

        public async Task<List<Aula>> GetPaginado(IQueryable<Aula> queryble, int limite, int excluir)
        {
            return queryble.OrderBy(a => a.Id)
                           .Skip(excluir)
                           .Take(limite)
                           .ToList();
        }

        public async Task<IQueryable<Aula>> GetQueryable()
        {
            IQueryable<Aula> aula = _sisContext.Aulas.AsQueryable();
            return aula;
        }

        public async Task<bool> verificarAula(int id)
        {
            bool verificarAula = await _sisContext.Aulas.AnyAsync(a => a.Id == id);
            return verificarAula;
        }
    }
}
