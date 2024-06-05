using Domain.Entity;

namespace Domain.IRepositories
{
    public interface ICursoRepository
    {
        Task<List<Curso>> GetAll();
        Task<Curso> GetById(int id);
        Task Create(Curso curso);
        void Delete(Curso curso);
        Task<List<Curso>> GetPaginado(IQueryable<Curso> queryable, int limite, int excluir);
        Task<IQueryable<Curso>> GetQueryable();
        Task<bool> verificarCurso(int id);

    }
}
