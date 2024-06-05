using Application.Dtos.Response;
using Application.Dtos.Resquest;

namespace Application.Interfaces
{
    public interface ICursoService
    {
        Task<List<CursoDto>> GetAll();
        Task<CursoDto> GetById(int id);
        Task<int> Create(CursoParametroDto cursoParametroDto);
        Task Update(CursoParametroDto cursoParametroDto);
        Task Delete(int id);
        Task<PaginacionDto<CursoDto>> GetCursosPaginados(FiltroCursoParametroDto filtroCursoParametroDto);
    }
}
