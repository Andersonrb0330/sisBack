using Application.Dtos.Response;
using Application.Dtos.Resquest;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApiSis.Controllers
{
    [Route("api/categoria")]
    public class CategoriaController : Controller
    {
        private readonly ICategoriaService _categoriaService;
        public CategoriaController(
            ICategoriaService categoriaService) 
        {
            _categoriaService = categoriaService;
        }

        [HttpPost("paginado")]
        public async Task<ActionResult<PaginacionDto<CategoriaDto>>> GetCategoriaPaginados([FromBody] FiltroCategoriaParametroDto filtroCategoriaParametroDto)
        { 
            PaginacionDto<CategoriaDto> categoriaPaginados = await _categoriaService.GetCategoriaPaginados(filtroCategoriaParametroDto);
            return Ok(categoriaPaginados);
        }


        [HttpGet]
        public async Task<ActionResult<List<CategoriaDto>>> GetAll()
        {
            List<CategoriaDto> listCategoria = await _categoriaService.GetAll();
            return listCategoria;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoriaDto>> GetById(int id)
        { 
            CategoriaDto categoriaDto = await _categoriaService.GetById(id);
            return Ok(categoriaDto);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CategoriaParametroDto categoriaParametroDto)
        {
            int id = await _categoriaService.Create(categoriaParametroDto);
            return id;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] CategoriaParametroDto categoriaParametroDto)
        { 
            categoriaParametroDto.Id = id;
            await _categoriaService.Update(categoriaParametroDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _categoriaService.Delete(id);
            return Ok();
        }
    }
}
