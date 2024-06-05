using Domain.Entity;

namespace Domain.IRepositories
{
    public interface IAlumnoRepository
    {
        Task<List<Alumno>> GetAll();
        Task<Alumno> GetById(int id);
        Task Create(Alumno alumno);
        void Delete(Alumno alumno);
        Task<List<Alumno>> GetPaginado(IQueryable<Alumno> queryable, int limite, int excluir);
        Task<IQueryable<Alumno>> GetQueryable();
        Task<bool> verificarAlumno(int id);
    }
}
