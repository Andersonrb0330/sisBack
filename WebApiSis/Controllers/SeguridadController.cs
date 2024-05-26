using Application.Dtos.Response;
using Application.Dtos.Resquest;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApiSis.Controllers
{
    [Route("api/seguridad")]
    public class SeguridadController : Controller
    {
        private readonly ISeguridadService _seguridadService;

        public SeguridadController(
            ISeguridadService seguridadService)
        {
            _seguridadService = seguridadService;
        }

        [HttpPost]
        public async Task<ActionResult<SeguridadDto>> Seguridad([FromBody] LoginParametroDto loginParametroDto)
        {
            SeguridadDto seguridadDto = await _seguridadService.Seguridad(loginParametroDto);
            return seguridadDto;
        }
    }
}
