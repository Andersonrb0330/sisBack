using Application.Dtos.Response;
using Application.Dtos.Resquest;
using Application.Interfaces;
using AutoMapper;
using Domain.Entity;
using Domain.IRepositories;
using FluentValidation;

namespace Application.Implementaciones
{
    public class AlumnoService : IAlumnoService
    {
        private readonly IAlumnoRepository _alumnoRepositoy;
        private readonly IAulaRepository _aulaRepository;
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IValidator<AlumnoParametroDto> _valitorAlumnoParametroDto;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AlumnoService(
            IAlumnoRepository alumnoRepository,
            IAulaRepository aulaRepository,
            ICategoriaRepository categoriaRepository,
            IValidator<AlumnoParametroDto> validator,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _alumnoRepositoy = alumnoRepository;
            _aulaRepository = aulaRepository;
            _categoriaRepository = categoriaRepository;
            _valitorAlumnoParametroDto = validator;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<AlumnoDto>> GetAll()
        {
            List<Alumno> alumno = await _alumnoRepositoy.GetAll();
            List<AlumnoDto> alumnoDto = _mapper.Map<List<AlumnoDto>>(alumno);
            return alumnoDto;
        }

        public async Task<AlumnoDto> GetById(int id)
        {
            Alumno alumno = await _alumnoRepositoy.GetById(id);
            AlumnoDto alumnoDto = _mapper.Map<AlumnoDto>(alumno);
            return alumnoDto;
        }

        public async Task<int> Create(AlumnoParametroDto alumnoParametroDto)
        {
            var validationResult = _valitorAlumnoParametroDto.Validate(alumnoParametroDto);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            bool existeAula = await _aulaRepository.verificarAula(alumnoParametroDto.IdAula);
            if (existeAula == false)
            {
                throw new Exception($"El ID {alumnoParametroDto.IdAula} del Aula no existe");
            }

            bool existeCategoria = await _categoriaRepository.verificarCategoria(alumnoParametroDto.IdCategoria);
            if (existeCategoria == false)
            {
                throw new Exception($"El ID {alumnoParametroDto.IdCategoria} de la Categoria no existe");
            }

            Alumno alumno = new Alumno
            {
                Nombres = alumnoParametroDto.Nombres,
                Apellidos = alumnoParametroDto.Apellidos,
                Telefono = alumnoParametroDto.Telefono,
                Edad = alumnoParametroDto.Edad,
                IdAula = alumnoParametroDto.IdAula,
                IdCategoria = alumnoParametroDto.IdCategoria
            };

            await _alumnoRepositoy.Create(alumno);
            await _unitOfWork.SaveChangesAsync();
            return alumno.Id;

        }

        public async Task Update(AlumnoParametroDto alumnoParametroDto)
        {
            Alumno alumno = await _alumnoRepositoy.GetById(alumnoParametroDto.Id);
            if (alumno == null)
            {
                throw new Exception($"No existe Alumno con este ID: {alumnoParametroDto.Id}");
            }

            alumno.Nombres = alumnoParametroDto.Nombres;
            alumno.Apellidos = alumnoParametroDto.Apellidos;
            alumno.Telefono = alumnoParametroDto.Telefono;
            alumno.Edad = alumnoParametroDto.Edad;
            alumno.IdAula = alumnoParametroDto.IdAula;
            alumno.IdCategoria = alumnoParametroDto.IdCategoria;

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            Alumno alumno = await _alumnoRepositoy.GetById(id);
            if (alumno == null)
            {
                throw new Exception($"No existe Alumno con este ID: {id}");
            }

            _alumnoRepositoy.Delete(alumno);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<PaginacionDto<AlumnoDto>> GetAlumnosPaginados(FiltroAlumnoParametroDto filtroAlumnoParametroDto)
        {
            IQueryable<Alumno> consulta = await _alumnoRepositoy.GetQueryable();

            // Aplicar filtros
            if (!string.IsNullOrWhiteSpace(filtroAlumnoParametroDto.Nombres))
            {
                consulta = consulta.Where(a => a.Nombres.Contains(filtroAlumnoParametroDto.Nombres));
            }
            if (!string.IsNullOrWhiteSpace(filtroAlumnoParametroDto.Apellidos))
            {
                consulta = consulta.Where(a => a.Apellidos.Contains(filtroAlumnoParametroDto.Apellidos));
            }
            if (!string.IsNullOrWhiteSpace(filtroAlumnoParametroDto.Telefono))
            {
                consulta = consulta.Where(a => a.Telefono.Contains(filtroAlumnoParametroDto.Telefono));
            }
            if (filtroAlumnoParametroDto.Edad.HasValue)
            {
                consulta = consulta.Where(a => a.Edad == filtroAlumnoParametroDto.Edad.Value);
            }
            if (filtroAlumnoParametroDto.IdAula.HasValue)
            {
                consulta = consulta.Where(a => a.IdAula == filtroAlumnoParametroDto.IdAula.Value);
            }
            if (filtroAlumnoParametroDto.IdCategoria.HasValue)
            {
                consulta = consulta.Where(a => a.IdCategoria == filtroAlumnoParametroDto.IdCategoria.Value);
            }

            int totalAlumnos = consulta.Count();
            // Obtener el totoal de paginas Math.Ceiling 
            int totalPages = (int)Math.Ceiling((double)totalAlumnos / filtroAlumnoParametroDto.Limite);
            var excluirElementos = filtroAlumnoParametroDto.Limite * filtroAlumnoParametroDto.Pagina;
            var alumnosPaginados = await _alumnoRepositoy.GetPaginado(consulta, filtroAlumnoParametroDto.Limite, excluirElementos);
            var alumnosDto = _mapper.Map<List<AlumnoDto>>(alumnosPaginados);
            var paginacionDto = new PaginacionDto<AlumnoDto>
            {
                TotalItems = totalAlumnos,
                PaginaActual = filtroAlumnoParametroDto.Pagina + 1,
                TotalPaginas = totalPages,
                Items = alumnosDto
            };
            return paginacionDto;
        }
    }
}
