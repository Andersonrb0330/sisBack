using Domain.Entity;

namespace Domain.IRepositories
{
    public interface ICategoriaRepository
    {
        Task<List<Categoria>> GetAll();
        Task<Categoria> GetById(int id);
        Task Create (Categoria categoria);
        void Delete (Categoria categoria);
        Task<List<Categoria>> GetPaginado(IQueryable<Categoria> queryable, int limite, int excluir);
        Task<IQueryable<Categoria>> GetQueryable();
        Task<bool> verificarCategoria(int id);
    }
}
