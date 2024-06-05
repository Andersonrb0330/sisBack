using Domain.Entity;
using Domain.IRepositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class MatriculaRepository : IMatriculaRepository
    {
        private readonly ISisContext _sisContext;

        public MatriculaRepository(
            ISisContext sisContext) 
        {
            _sisContext = sisContext;
        }

        public async Task<List<Matricula>> GetAll()
        {
            List<Matricula> listMatricula = await _sisContext.Matriculas
                .Include(m => m.Login)
                .Include(m => m.Alumno)
                .ToListAsync();
            return listMatricula;
        }

        public async Task<Matricula> GetById(int id)
        {
            Matricula matricula = await _sisContext.Matriculas
               .Include(m => m.Login)
               .Include(m => m.Alumno)
               .FirstOrDefaultAsync(m => m.Id == id);
            return matricula;
        }

        public async Task Create(Matricula matricula)
        {
            await _sisContext.Matriculas.AddAsync(matricula);
        }

        public void Delete(Matricula matricula)
        {
            _sisContext.Matriculas.Remove(matricula);
        }

        public async Task<List<Matricula>> GetPaginado(IQueryable<Matricula> queryable, int limite, int excluir)
        {
            return queryable
                 .Include(c => c.Login)
                 .Include(c => c.Alumno)
                 .OrderBy(c => c.Id)
                 .Skip(excluir)
                 .Take(limite)
                 .ToList();
        }

        public async Task<IQueryable<Matricula>> GetQueryable()
        {
            IQueryable<Matricula> matricula = _sisContext.Matriculas.AsQueryable();
            return matricula;
        }

        public async Task<bool> verificarMatricula(int id)
        {
            bool verificarMatriculas = await _sisContext.Matriculas.AnyAsync(m => m.Id == id);
            return verificarMatriculas;
        }
    }
}
