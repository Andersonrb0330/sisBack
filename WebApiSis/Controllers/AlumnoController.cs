using Application.Dtos.Response;
using Application.Dtos.Resquest;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApiSis.Controllers
{
    [Route("api/alumnos")]
    public class AlumnoController : Controller
    {
        private readonly IAlumnoService _alumnoService;

        public AlumnoController(
            IAlumnoService alumnoService)
        {
            _alumnoService = alumnoService;
        }

        [HttpPost("paginado")]
        public async Task<ActionResult<PaginacionDto<AlumnoDto>>> GetAlumnoPaginados([FromBody] FiltroAlumnoParametroDto filtroAlumnoParametroDto)
        {
            PaginacionDto<AlumnoDto> alumnoPaginado = await _alumnoService.GetAlumnosPaginados(filtroAlumnoParametroDto);
            return Ok(alumnoPaginado);
        }

        [HttpGet]
        public async Task<ActionResult<List<AlumnoDto>>> GetAll()
        {
            List<AlumnoDto> listAlumno = await _alumnoService.GetAll();
            return Ok(listAlumno);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AlumnoDto>> GetById(int id)
        {
            AlumnoDto alumnoDto = await _alumnoService.GetById(id);
            return Ok(alumnoDto);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] AlumnoParametroDto alumnoParametroDto)
        {
            int id = await _alumnoService.Create(alumnoParametroDto);
            return id;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] AlumnoParametroDto alumnoParametroDto)
        {
            alumnoParametroDto.Id = id;
            await _alumnoService.Update(alumnoParametroDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        { 
            await _alumnoService.Delete(id);
            return Ok();
        }
    }
}
