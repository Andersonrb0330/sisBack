using Application.Dtos.Response;
using Application.Dtos.Resquest;

namespace Application.Interfaces
{
    public interface IMaestroDetalleService
    {
        Task<List<MaestroDetalleDto>> GetAll();
        Task<MaestroDetalleDto> GetById(int id);
        Task<int> Create(MaestroDetalleParametroDto maestroDetalleParametroDto);
        Task Update(MaestroDetalleParametroDto maestroDetalleParametroDto);
        Task Delete(int id);
        Task<PaginacionDto<MaestroDetalleDto>> GetMaestroDetallePaginados(FiltroMaestroDetalleParametroDto maestroDetalleParametroDto);
    }
}
