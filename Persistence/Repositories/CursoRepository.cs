using Domain.Entity;
using Domain.IRepositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class CursoRepository : ICursoRepository
    {
        private readonly ISisContext _sisContext;

        public CursoRepository(
            ISisContext sisContext) 
        {
            _sisContext = sisContext;
        }
        public async Task<List<Curso>> GetAll()
        {
            List<Curso> listCurso = await _sisContext.Cursos
                .ToListAsync();
            return listCurso;
        }

        public async Task<Curso> GetById(int id)
        {
            Curso curso = await _sisContext.Cursos
                .FirstOrDefaultAsync(c => c.Id == id);
            return curso;
        }

        public async Task Create(Curso curso)
        {
            await _sisContext.Cursos.AddAsync(curso);
        }

        public void Delete(Curso curso)
        {
            _sisContext.Cursos.Remove(curso);
        }

        public async Task<List<Curso>> GetPaginado(IQueryable<Curso> queryable, int limite, int excluir)
        {
            return queryable
                .OrderBy(a => a.Id)
                .Skip(excluir)
                .Take(limite)
                .ToList();
        }

        public async Task<IQueryable<Curso>> GetQueryable()
        {
            IQueryable<Curso> curso = _sisContext.Cursos.AsQueryable();
            return curso;
        }

        public async Task<bool> verificarCurso(int id)
        {
            bool verificarCurso = await _sisContext.Cursos.AnyAsync(c => c.Id == id);
            return verificarCurso;
        }
    }
}
