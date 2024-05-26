using Application.Dtos.Response;
using Application.Dtos.Resquest;

namespace Application.Interfaces
{
    public interface ILoginService
    {
        Task<List<LoginDto>> Get();
        Task<LoginDto> GetById(int id);
        Task<int> Create(LoginParametroDto loginParametroDto);
        Task Update(LoginParametroDto loginParametroDto);
        Task Delete(int id);
    }
}
