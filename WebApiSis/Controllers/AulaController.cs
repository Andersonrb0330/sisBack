using Application.Dtos.Response;
using Application.Dtos.Resquest;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebApiSis.Controllers
{
    [Route("api/aula")]
    public class AulaController : Controller
    {
        private readonly IAulaService _aulaService;

        public AulaController(
            IAulaService aulaService) 
        {
            _aulaService = aulaService;
        }

        [HttpPost("paginado")]
        public async Task<ActionResult<PaginacionDto<AulaDto>>> GetAulaPaginados([FromBody] FiltroAulaParametroDto filtroAulaParametroDto)
        {
            PaginacionDto<AulaDto> aulaPaginados = await _aulaService.GetAulaPaginados(filtroAulaParametroDto);
            return Ok(aulaPaginados);
        }

        [HttpGet]
        public async Task<ActionResult<List<AulaDto>>> GetAll()
        {
            List<AulaDto> listAula = await _aulaService.GetAll();
            return Ok(listAula);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AulaDto>> GetById(int id)
        { 
            AulaDto aulaDto = await _aulaService.GetById(id);
            return Ok(aulaDto);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] AulaParametroDto aulaParametroDto)
        {
            int id = await _aulaService.Create(aulaParametroDto);
            return Ok(id);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] AulaParametroDto aulaParametroDto)
        { 
            aulaParametroDto.Id = id;
            await _aulaService.Update(aulaParametroDto);
            return Ok(id);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id) 
        {
            await _aulaService.Delete(id);
            return Ok();
             
        }
    }
}
