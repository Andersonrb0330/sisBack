using Application.Dtos.Response;
using Application.Dtos.Resquest;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApiSis.Controllers
{
    [Authorize]
    [Route("api/login")]
    public class LoginController : Controller
    {
        private readonly ILoginService _loginService;

        public LoginController(
            ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpGet]
        public async Task<ActionResult<List<LoginDto>>> Get()
        {
            List<LoginDto> loginDto = await _loginService.Get();
            return Ok(loginDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LoginDto>> GetById(int id)
        {
            LoginDto loginDto = await _loginService.GetById(id);
            return Ok(loginDto);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] LoginParametroDto loginParametroDto)
        {
            int id = await _loginService.Create(loginParametroDto);
            return id;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id ,[FromBody] LoginParametroDto loginParametroDto)
        {
            loginParametroDto.Id = id;
            await _loginService.Update(loginParametroDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _loginService.Delete(id);
            return Ok();
        }

    }
}
