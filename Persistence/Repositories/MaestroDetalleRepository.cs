using Domain.Entity;
using Domain.IRepositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class MaestroDetalleRepository : IMaestroDetalleRepository
    {
        private readonly SisContext _sisContext;
        public MaestroDetalleRepository(
            SisContext sisContext)
        {
            _sisContext = sisContext;
        }
        public async Task<List<MaestroDetalle>> GetAll()
        {
           List<MaestroDetalle> listMaestroDetalle = await _sisContext.MaestroDetalles
                .Include(md => md.Matricula)
                .Include(md => md.Curso)
                .ToListAsync();
            return listMaestroDetalle;
        }

        public async Task<MaestroDetalle> GetById(int id)
        {
            MaestroDetalle maestroDetalle = await _sisContext.MaestroDetalles
                .Include(md => md.Matricula)
                .Include(md => md.Curso)
                .FirstOrDefaultAsync(md => md.Id == id);
            return maestroDetalle;
        }

        public async Task Create(MaestroDetalle maestroDetalle)
        {
            await _sisContext.MaestroDetalles.AddAsync(maestroDetalle);
        }

        public void Delete(MaestroDetalle maestroDetalle)
        {
            _sisContext.MaestroDetalles.Remove(maestroDetalle);
        }

        public async Task<List<MaestroDetalle>> GetPaginado(IQueryable<MaestroDetalle> queryable, int limite, int excluir)
        {
            return queryable
                .Include(c => c.Matricula)
                .Include(c => c.Curso)
                .OrderBy(c => c.Id)
                .Skip(excluir)
                .Take(limite)
                .ToList();
        }

        public async Task<IQueryable<MaestroDetalle>> GetQueryable()
        {

            IQueryable<MaestroDetalle> maestroDetalle = _sisContext.MaestroDetalles.AsQueryable();
            return maestroDetalle;
        }
    }
}
