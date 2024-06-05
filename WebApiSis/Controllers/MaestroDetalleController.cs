using Application.Dtos.Response;
using Application.Dtos.Resquest;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApiSis.Controllers
{
    [Route("api/maestro-detalle")]
    public class MaestroDetalleController : Controller
    {
        private readonly IMaestroDetalleService _maestroDetalleService;

        public MaestroDetalleController(IMaestroDetalleService maestroDetalleService)
        {
            _maestroDetalleService = maestroDetalleService;
        }

        [HttpPost("paginado")]
        public async Task<ActionResult<PaginacionDto<MaestroDetalleDto>>> GetMaestroDetallePaginados([FromBody] FiltroMaestroDetalleParametroDto filtroMaestroDetalleParametroDto)
        {
            PaginacionDto<MaestroDetalleDto> maestroDetallePaginado = await _maestroDetalleService.GetMaestroDetallePaginados(filtroMaestroDetalleParametroDto);
            return Ok(maestroDetallePaginado);
        }

        [HttpGet]
        public async Task<ActionResult<List<MaestroDetalleDto>>> GetAll()
        {
            List<MaestroDetalleDto> listMaestroDetalleDto = await _maestroDetalleService.GetAll();
            return Ok(listMaestroDetalleDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MaestroDetalleDto>> GetById(int id)
        {
            MaestroDetalleDto maestroDetalleDto = await _maestroDetalleService.GetById(id);
            return Ok(maestroDetalleDto);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] MaestroDetalleParametroDto maestroDetalleParametroDto)
        {
            int id = await _maestroDetalleService.Create(maestroDetalleParametroDto);
            return Ok(id);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] MaestroDetalleParametroDto maestroDetalleParametroDto)
        {
            maestroDetalleParametroDto.Id = id;
            await _maestroDetalleService.Update(maestroDetalleParametroDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _maestroDetalleService.Delete(id);
            return Ok();
        }
    }
}
