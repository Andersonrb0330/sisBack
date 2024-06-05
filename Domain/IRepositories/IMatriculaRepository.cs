using Domain.Entity;

namespace Domain.IRepositories
{
    public interface IMatriculaRepository
    {
        Task<List<Matricula>> GetAll();
        Task<Matricula> GetById(int id);
        Task Create(Matricula matricula);
        void Delete(Matricula matricula);
        Task<List<Matricula>> GetPaginado(IQueryable<Matricula> queryable, int limite, int excluir);
        Task<IQueryable<Matricula>> GetQueryable();
        Task<bool> verificarMatricula(int id);

    }
}
