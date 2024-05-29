using Domain.Entity;

namespace Domain.IRepositories
{
    public interface IAulaRepository
    {
        Task<List<Aula>> GetAll();
        Task<Aula> GetById(int id);
        Task Create (Aula aula);
        void Delete(Aula aula);
        Task<List<Aula>> GetPaginado(IQueryable<Aula> queryble, int limite, int excluir);
        Task<IQueryable<Aula>> GetQueryable();

        Task<bool> verificarAula(int id);
    }
}
