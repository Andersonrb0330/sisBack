using Application.Dtos.Response;
using Application.Dtos.Resquest;
using Domain.Entity;

namespace Application.Interfaces
{
    public interface ISeguridadService
    {
        Task<SeguridadDto> Seguridad(LoginParametroDto loginParametroDto);
        string GenerateJwtToken(Login login);
    }
}
