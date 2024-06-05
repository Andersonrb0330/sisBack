using Application.Dtos.Response;
using Application.Dtos.Resquest;
using Application.Interfaces;
using AutoMapper;
using Domain.Entity;
using Domain.IRepositories;
using FluentValidation;

namespace Application.Implementaciones
{
    public class CursoService : ICursoService
    {
        private readonly ICursoRepository _cursoRepository;
        private readonly IValidator<CursoParametroDto> _valitorCursoParametroDto;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CursoService(
            ICursoRepository cursoRepository,
            IValidator<CursoParametroDto> validator,
            IUnitOfWork unitOfWork,
            IMapper mapper) 
        { 
            _cursoRepository = cursoRepository;
            _valitorCursoParametroDto = validator;
            _unitOfWork = unitOfWork;   
            _mapper = mapper;
        }

        public async Task<List<CursoDto>> GetAll()
        {
            List<Curso> curso = await _cursoRepository.GetAll();
            List<CursoDto> cursoDto = _mapper.Map<List<CursoDto>>(curso);
            return cursoDto;
        }

        public async Task<CursoDto> GetById(int id)
        {
            Curso curso = await _cursoRepository.GetById(id);
            CursoDto cursoDto = _mapper.Map<CursoDto>(curso);  
            return cursoDto;
        }


        public async Task<int> Create(CursoParametroDto cursoParametroDto)
        {
            var validationResult = _valitorCursoParametroDto.Validate(cursoParametroDto);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            Curso curso = new Curso
            {
                Nombre = cursoParametroDto.Nombre,
                Descripcion = cursoParametroDto.Descripcion
            };

            await _cursoRepository.Create(curso);
            await _unitOfWork.SaveChangesAsync();
            return curso.Id;
        }

        public async Task Update(CursoParametroDto cursoParametroDto)
        {
           Curso curso = await _cursoRepository.GetById(cursoParametroDto.Id);
            if (curso == null)
            {
                throw new Exception($"No existe Curso con este ID: {cursoParametroDto.Id}");
            }

            curso.Nombre = cursoParametroDto.Nombre;
            curso.Descripcion = cursoParametroDto.Descripcion;

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            Curso curso = await _cursoRepository.GetById(id);
            if (curso == null)
            {
                throw new Exception($"No existe Curso con este ID: {id}");
            }

            _cursoRepository.Delete(curso);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<PaginacionDto<CursoDto>> GetCursosPaginados(FiltroCursoParametroDto filtroCursoParametroDto)
        {
            IQueryable<Curso> consulta = await _cursoRepository.GetQueryable();

            // Aplicar filtros
            if (!string.IsNullOrWhiteSpace(filtroCursoParametroDto.Nombre))
            {
                consulta = consulta.Where(a => a.Nombre.Contains(filtroCursoParametroDto.Nombre));
            }
            if (!string.IsNullOrWhiteSpace(filtroCursoParametroDto.Descripcion))
            {
                consulta = consulta.Where(a => a.Descripcion.Contains(filtroCursoParametroDto.Descripcion));
            }

            int totalCursos = consulta.Count();
            // Obtener el totoal de paginas Math.Ceiling 
            int totalPages = (int)Math.Ceiling((double)totalCursos / filtroCursoParametroDto.Limite);
            var excluirElementos = filtroCursoParametroDto.Limite * filtroCursoParametroDto.Pagina;
            var cursosPaginados = await _cursoRepository.GetPaginado(consulta, filtroCursoParametroDto.Limite, excluirElementos);
            var cursosDto = _mapper.Map<List<CursoDto>>(cursosPaginados);
            var paginacionDto = new PaginacionDto<CursoDto>
            {
                TotalItems = totalCursos,
                PaginaActual = filtroCursoParametroDto.Pagina + 1,
                TotalPaginas = totalPages,
                Items = cursosDto
            };
            return paginacionDto;
        }
    }
}
