using Application.Dtos.Response;
using Application.Dtos.Resquest;

namespace Application.Interfaces
{
    public interface ICategoriaService
    {
        Task<List<CategoriaDto>> GetAll();
        Task<CategoriaDto> GetById(int id);
        Task<int> Create(CategoriaParametroDto categoriaParametroDto);
        Task Update(CategoriaParametroDto categoriaParametroDto);
        Task Delete(int id);
        Task<PaginacionDto<CategoriaDto>> GetCategoriaPaginados(FiltroCategoriaParametroDto filtroCategoriaParametroDto);
    }
}
