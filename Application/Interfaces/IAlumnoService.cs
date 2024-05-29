using Application.Dtos.Response;
using Application.Dtos.Resquest;

namespace Application.Interfaces
{
    public interface IAlumnoService
    {
        Task<List<AlumnoDto>> GetAll();
        Task<AlumnoDto> GetById(int id);
        Task<int> Create(AlumnoParametroDto alumnoParametroDto);
        Task Update(AlumnoParametroDto alumnoParametroDto);
        Task Delete(int id);
        Task<PaginacionDto<AlumnoDto>> GetAlumnosPaginados(FiltroAlumnoParametroDto filtroAlumnoParametroDto);
    }
}
