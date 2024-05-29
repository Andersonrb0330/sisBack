using Application.Dtos.Response;
using Application.Dtos.Resquest;

namespace Application.Interfaces
{
    public interface IAulaService
    {
        Task<List<AulaDto>> GetAll();
        Task<AulaDto> GetById(int id);
        Task <int> Create(AulaParametroDto aulaParametroDto);
        Task Update(AulaParametroDto aulaParametroDto);
        Task Delete(int id);
        Task<PaginacionDto<AulaDto>> GetAulaPaginados(FiltroAulaParametroDto filtroAulaParametroDto);

    }
}
