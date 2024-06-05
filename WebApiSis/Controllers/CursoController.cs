using Application.Dtos.Response;
using Application.Dtos.Resquest;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApiSis.Controllers
{
    [Route("api/curso")]
    public class CursoController : Controller
    {
        private readonly ICursoService _cursoService;

        public CursoController(
            ICursoService cursoService)
        { 
            _cursoService = cursoService;
        }

        [HttpPost("paginado")]
        public async Task<ActionResult<PaginacionDto<CursoDto>>> GetCursoPaginados([FromBody] FiltroCursoParametroDto filtroCursoParametroDto)
        {
            PaginacionDto<CursoDto> cursoPaginado = await _cursoService.GetCursosPaginados(filtroCursoParametroDto);
            return Ok(cursoPaginado);
        }

        [HttpGet]
        public async Task<ActionResult<List<CursoDto>>> GetAll()
        { 
            List<CursoDto> listCurso = await _cursoService.GetAll();
            return Ok(listCurso);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CursoDto>> GetById(int id)
        { 
            CursoDto cursoDto = await _cursoService.GetById(id);
            return Ok(cursoDto);
        }


        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CursoParametroDto cursoParametroDto)
        {
            int id = await _cursoService.Create(cursoParametroDto);
            return id;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] CursoParametroDto cursoParametroDto)
        { 
            cursoParametroDto.Id = id;
            await _cursoService.Update(cursoParametroDto);
            return Ok();
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        { 
            await _cursoService.Delete(id);
            return Ok();
        }
    }
}
