using Domain.Entity;
using Domain.IRepositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class AlumnoRepository : IAlumnoRepository
    {
        private readonly SisContext _sisContext;

        public AlumnoRepository(
            SisContext sisContext)
        {
            _sisContext = sisContext;
        }
        public async Task<List<Alumno>> GetAll()
        {
            List<Alumno> listAlumno = await _sisContext.Alumnos
                .Include(a => a.Aula)
                .Include(a => a.Categoria)
                .ToListAsync();
            return listAlumno;
        }

        public async Task<Alumno> GetById(int id)
        {
            Alumno alumno = await _sisContext.Alumnos
                .Include(a => a.Aula)
                .Include(a => a.Categoria)
                .FirstAsync(a => a.Id == id);
            return alumno;
        }

        public async Task Create(Alumno alumno)
        {
            await _sisContext.Alumnos.AddAsync(alumno);
        }

        public void Delete(Alumno alumno)
        {
            _sisContext.Alumnos.Remove(alumno);
        }

        public async Task<List<Alumno>> GetPaginado(IQueryable<Alumno> queryable, int limite, int excluir)
        {
            return queryable
                .Include(c => c.Aula)
                .Include(c => c.Categoria)
                .OrderBy(c => c.Id)
                .Skip(excluir)
                .Take(limite)
                .ToList();
        }

        public async Task<IQueryable<Alumno>> GetQueryable()
        {
            IQueryable<Alumno> alumno = _sisContext.Alumnos.AsQueryable();
            return alumno;
        }
    }
}
