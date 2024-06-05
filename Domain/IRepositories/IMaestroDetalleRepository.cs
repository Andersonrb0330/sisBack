using Domain.Entity;

namespace Domain.IRepositories
{
    public interface IMaestroDetalleRepository
    {
        Task<List<MaestroDetalle>> GetAll();
        Task<MaestroDetalle> GetById(int id);
        Task Create(MaestroDetalle maestroDetalle);
        void Delete(MaestroDetalle maestroDetalle);
        Task<List<MaestroDetalle>> GetPaginado(IQueryable<MaestroDetalle> queryable, int limite, int excluir);
        Task<IQueryable<MaestroDetalle>> GetQueryable();
    }
}
