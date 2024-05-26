using Application.Dtos.Response;
using Application.Dtos.Resquest;
using Application.Interfaces;
using AutoMapper;
using Domain.Entity;
using Domain.IRepositories;
using FluentValidation;


namespace Application.Implementaciones
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _loginRepository;
        private readonly IValidator<LoginParametroDto> _validarLogin;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LoginService(
            ILoginRepository loginRepository,
            IValidator<LoginParametroDto> validarLogin,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _loginRepository = loginRepository;
            _validarLogin = validarLogin;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<LoginDto>> Get()
        { 
            List<Login> login = await _loginRepository.Get();
            List<LoginDto> loginDto = _mapper.Map<List<LoginDto>>(login);
            return loginDto;
        }

        public async Task<LoginDto> GetById(int id)
        {
            Login login = await _loginRepository.GetById(id);
            LoginDto loginDto = _mapper.Map<LoginDto>(login);
            return loginDto;
        }

        public async Task Update (LoginParametroDto loginParametroDto)
        {
            Login login = await _loginRepository.GetById(loginParametroDto.Id);
            if (login == null)
            {
                throw new Exception($"NO existe el Usuario con este ID: {loginParametroDto.Id}");
            }
            login.Email = loginParametroDto.Email;
            login.Password = loginParametroDto.Password;

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<int> Create(LoginParametroDto loginParametroDto)
        {
            var validationResult = _validarLogin.Validate(loginParametroDto);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            bool existeEmail = await _loginRepository.VerificarEmail(loginParametroDto.Email);
            if (existeEmail == true)
            {
                throw new Exception("El Correo ya existe");
            }

            Login login = new Login
            {
                Email = loginParametroDto.Email,
                Password = loginParametroDto.Password
            };

            await _loginRepository.Create(login);
            await _unitOfWork.SaveChangesAsync();
            return login.Id;
        }

        public async Task Delete(int id)
        {
            Login login = await _loginRepository.GetById(id);
            if (login == null)
            {
                throw new Exception($"No existe el Usuario con el ID: {id}");
            }
            _loginRepository.Delete(login);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
