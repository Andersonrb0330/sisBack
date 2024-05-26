using Application.Common;
using Application.Dtos.Response;
using Application.Dtos.Resquest;
using Application.Interfaces;
using AutoMapper;
using Domain.Entity;
using Domain.IRepositories;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Application.Implementaciones
{
    public class SeguridadService : ISeguridadService
    {

        private readonly ILoginRepository _loginRepository;
        private readonly JwtConfig _jwtConfig;

        public SeguridadService(
            ILoginRepository loginRepository,
            IOptions<JwtConfig> options)
        {
            _loginRepository = loginRepository;
            _jwtConfig = options.Value;
        }


        public string GenerateJwtToken(Login login)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtConfig.Key);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, login.Id.ToString()),
                new Claim(ClaimTypes.Email, login.Email)
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(_jwtConfig.ExpiryInMinutes),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = _jwtConfig.Issuer,
                Audience = _jwtConfig.Audience
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public async Task<SeguridadDto> Seguridad(LoginParametroDto loginParametroDto)
        {
            Login login = await _loginRepository.LoginInfo(loginParametroDto.Email, loginParametroDto.Password);
            if (login == null)
                return null;

            string token = GenerateJwtToken(login);

            var seguridad = new SeguridadDto()
            {
                Token = token
            };
            return seguridad;
        }
    }
}
