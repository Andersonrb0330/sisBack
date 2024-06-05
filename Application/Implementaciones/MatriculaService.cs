using Application.Dtos.Response;
using Application.Dtos.Resquest;
using Application.Interfaces;
using AutoMapper;
using Domain.Entity;
using Domain.IRepositories;
using FluentValidation;

namespace Application.Implementaciones
{
    public class MatriculaService : IMatriculaService
    {
        private readonly IMatriculaRepository _matriculaRepository;
        private readonly ILoginRepository _loginRepository;
        private readonly IAlumnoRepository _alumnoRepository;
        private readonly IValidator<MatriculaParametroDto> _validatorMatriculaParametroDto;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MatriculaService(
            IMatriculaRepository matriculaRepository,
            ILoginRepository loginRepository,
            IAlumnoRepository alumnoRepository,
            IValidator<MatriculaParametroDto> validator,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _matriculaRepository = matriculaRepository;
            _loginRepository = loginRepository;
            _alumnoRepository = alumnoRepository;
            _validatorMatriculaParametroDto = validator;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<MatriculaDto>> GetAll()
        {
            List<Matricula> matricula = await _matriculaRepository.GetAll();
            List<MatriculaDto> matriculaDto = _mapper.Map<List<MatriculaDto>>(matricula);
            return matriculaDto;
        }

        public async Task<MatriculaDto> GetById(int id)
        {
            Matricula matricula = await _matriculaRepository.GetById(id);
            MatriculaDto matriculaDto = _mapper.Map<MatriculaDto>(matricula);
            return matriculaDto;
        }

        public async Task<int> Create(MatriculaParametroDto matriculaParametroDto)
        {
            var validationResult = _validatorMatriculaParametroDto.Validate(matriculaParametroDto);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            bool existeLogin = await _loginRepository.verificarLogin(matriculaParametroDto.IdLogin);
            if (existeLogin == false)
            {
                throw new Exception($"El ID {matriculaParametroDto.IdLogin} del Login no existe");
            }

            bool existeAlumno = await _alumnoRepository.verificarAlumno(matriculaParametroDto.IdAlumno);
            if (existeAlumno == false)
            {
                throw new Exception($"El ID {matriculaParametroDto.IdAlumno} del Alumno no existe");
            }

            Matricula matricula = new Matricula
            {
                Fecha = matriculaParametroDto.Fecha,
                IdLogin = matriculaParametroDto.IdLogin,
                IdAlumno = matriculaParametroDto.IdAlumno,
                Estado = matriculaParametroDto.Estado,
            };

            await _matriculaRepository.Create(matricula);
            await _unitOfWork.SaveChangesAsync();
            return matricula.Id;

        }

        public async Task Update(MatriculaParametroDto matriculaParametroDto)
        {
            Matricula matricula = await _matriculaRepository.GetById(matriculaParametroDto.Id);
            if (matricula == null)
            {
                throw new Exception($"No existe Matricula con este ID: {matriculaParametroDto.Id}");
            }

            matricula.IdLogin = matriculaParametroDto.IdLogin;
            matricula.IdAlumno = matriculaParametroDto.IdAlumno;
            matricula.Fecha = matriculaParametroDto.Fecha;
            matricula.Estado = matriculaParametroDto.Estado;

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            Matricula matricula = await _matriculaRepository.GetById(id);
            if (matricula == null)
            {
                throw new Exception($"No existe Matricula con este ID: {id}");
            }

            _matriculaRepository.Delete(matricula);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<PaginacionDto<MatriculaDto>> GetMatriculasPaginados(FiltroMatriculaParametroDto filtroMatriculaParametroDto)
        {
            IQueryable<Matricula> consulta = await _matriculaRepository.GetQueryable();

            if (!string.IsNullOrWhiteSpace(filtroMatriculaParametroDto.Estado))
            {
                consulta = consulta.Where(a => a.Estado.Contains(filtroMatriculaParametroDto.Estado));
            }

            if (filtroMatriculaParametroDto.Fecha.HasValue && filtroMatriculaParametroDto.Fecha != DateTime.MinValue)
            {
                consulta = consulta.Where(c => DateTime.Compare(c.Fecha, filtroMatriculaParametroDto.Fecha.Value) == 0);
            }

            if (filtroMatriculaParametroDto.IdLogin.HasValue)
            {
                consulta = consulta.Where(a => a.IdLogin == filtroMatriculaParametroDto.IdLogin.Value);
            }

            if (filtroMatriculaParametroDto.IdAlumno.HasValue)
            {
                consulta = consulta.Where(a => a.IdAlumno == filtroMatriculaParametroDto.IdAlumno.Value);
            }

            int totalMatriculas = consulta.Count();
            // Obtener el totoal de paginas Math.Ceiling 
            int totalPages = (int)Math.Ceiling((double)totalMatriculas / filtroMatriculaParametroDto.Limite);
            var excluirElementos = filtroMatriculaParametroDto.Limite * filtroMatriculaParametroDto.Pagina;
            var matriculasPaginados = await _matriculaRepository.GetPaginado(consulta, filtroMatriculaParametroDto.Limite, excluirElementos);
            var matriculasDto = _mapper.Map<List<MatriculaDto>>(matriculasPaginados);
            var paginacionDto = new PaginacionDto<MatriculaDto>
            {
                TotalItems = totalMatriculas,
                PaginaActual = filtroMatriculaParametroDto.Pagina + 1,
                TotalPaginas = totalPages,
                Items = matriculasDto
            };
            return paginacionDto;
        }
    }
}
