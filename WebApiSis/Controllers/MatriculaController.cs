using Application.Dtos.Response;
using Application.Dtos.Resquest;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApiSis.Controllers
{
    [Route("api/matriculas")]
    public class MatriculaController : Controller
    {
        private readonly IMatriculaService _matriculaService;

        public MatriculaController(
            IMatriculaService matriculaService)
        {
            _matriculaService = matriculaService;
        }

        [HttpPost("paginado")]
        public async Task<ActionResult<PaginacionDto<MatriculaDto>>> GetMatriculaPaginados([FromBody] FiltroMatriculaParametroDto filtroMatriculaParametroDto)
        {
            PaginacionDto<MatriculaDto> matriculaPaginado = await _matriculaService.GetMatriculasPaginados(filtroMatriculaParametroDto);
            return Ok(matriculaPaginado);
        }

        [HttpGet]
        public async Task<ActionResult<List<MatriculaDto>>> GetAll()
        {
            List<MatriculaDto> matriculaDto = await _matriculaService.GetAll();
            return Ok(matriculaDto);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<MatriculaDto>> GetById(int id)
        {
            MatriculaDto matriculaDto = await _matriculaService.GetById(id);
            return Ok(matriculaDto);
        }
        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] MatriculaParametroDto matriculaParametroDto)
        {
            int id = await _matriculaService.Create(matriculaParametroDto);
            return id;
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] MatriculaParametroDto matriculaParametroDto)
        {
            matriculaParametroDto.Id = id;
            await _matriculaService.Update(matriculaParametroDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _matriculaService.Delete(id);
            return Ok();
        }
    }
}
