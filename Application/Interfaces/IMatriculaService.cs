using Application.Dtos.Response;
using Application.Dtos.Resquest;

namespace Application.Interfaces
{
    public interface IMatriculaService
    {
        Task<List<MatriculaDto>> GetAll();
        Task<MatriculaDto> GetById(int id);
        Task<int> Create(MatriculaParametroDto matriculaParametroDto);
        Task Update(MatriculaParametroDto matriculaParametroDto);
        Task Delete(int id);
        Task<PaginacionDto<MatriculaDto>> GetMatriculasPaginados(FiltroMatriculaParametroDto matriculaParametroDto);
    }
}
