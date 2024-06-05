using Application.Dtos.Response;
using Application.Dtos.Resquest;
using Application.Interfaces;
using AutoMapper;
using Domain.Entity;
using Domain.IRepositories;
using FluentValidation;
using Persistence.Repositories;

namespace Application.Implementaciones
{
    public class MaestroDetalleService : IMaestroDetalleService
    {
        private readonly IMaestroDetalleRepository _maestroDetalleRepository;
        private readonly IMatriculaRepository _matriculaRepository;
        private readonly ICursoRepository _cursoRepository;
        private readonly IValidator<MaestroDetalleParametroDto> _valitorMaestroDetalleParametroDto;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MaestroDetalleService(
            IMaestroDetalleRepository IMaestroDetalleRepository,
            IMatriculaRepository matriculaRepository,
            ICursoRepository cursoRepository,
            IValidator<MaestroDetalleParametroDto> validator,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _maestroDetalleRepository = IMaestroDetalleRepository;
            _matriculaRepository = matriculaRepository;
            _cursoRepository = cursoRepository;
            _valitorMaestroDetalleParametroDto = validator;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<MaestroDetalleDto>> GetAll()
        {
            List<MaestroDetalle> maestroDetalle = await _maestroDetalleRepository.GetAll();
            List<MaestroDetalleDto> maestroDetalleDto = _mapper.Map<List<MaestroDetalleDto>>(maestroDetalle);
            return maestroDetalleDto;
        }

        public async Task<MaestroDetalleDto> GetById(int id)
        {
            MaestroDetalle maestroDetalle = await _maestroDetalleRepository.GetById(id);
            MaestroDetalleDto maestroDetalleDto = _mapper.Map<MaestroDetalleDto>(maestroDetalle);
            return maestroDetalleDto;
        }

        public async Task<int> Create(MaestroDetalleParametroDto maestroDetalleParametroDto)
        {
            var validationResult = _valitorMaestroDetalleParametroDto.Validate(maestroDetalleParametroDto);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            bool existeCurso = await _cursoRepository.verificarCurso(maestroDetalleParametroDto.IdCurso);
            if (existeCurso == false)
            {
                throw new Exception($"El ID {maestroDetalleParametroDto.IdCurso} del curso no existe");
            }

            bool existeMatricula = await _matriculaRepository.verificarMatricula(maestroDetalleParametroDto.IdMatricula);
            if (existeMatricula == false)
            {
                throw new Exception($"El ID {maestroDetalleParametroDto.IdMatricula} de la matricula no existe");
            }

            MaestroDetalle maestroDetalle = new MaestroDetalle
            {
                IdMatricula = maestroDetalleParametroDto.IdMatricula,
                IdCurso = maestroDetalleParametroDto.IdCurso,
                Acreditado = maestroDetalleParametroDto.Acreditado,
                Estado = maestroDetalleParametroDto.Estado
            };

            await _maestroDetalleRepository.Create(maestroDetalle);
            await _unitOfWork.SaveChangesAsync();

            return maestroDetalle.Id;
        }

        public async Task Update(MaestroDetalleParametroDto maestroDetalleParametroDto)
        {
            MaestroDetalle maestroDetalle = await _maestroDetalleRepository.GetById(maestroDetalleParametroDto.Id);
            if (maestroDetalle == null)
            {
                throw new Exception($"No existe MaestroDetalle con este ID: {maestroDetalleParametroDto.Id}");
            }

            maestroDetalle.IdMatricula = maestroDetalleParametroDto.IdMatricula;
            maestroDetalle.IdCurso = maestroDetalleParametroDto.IdCurso;
            maestroDetalle.Acreditado = maestroDetalleParametroDto.Acreditado;
            maestroDetalle.Estado = maestroDetalleParametroDto.Estado;

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            MaestroDetalle maestroDetalle = await _maestroDetalleRepository.GetById(id);
            if (maestroDetalle == null)
            {
                throw new Exception($"No existe MaestroDetalle con este ID: {id}");
            }

            _maestroDetalleRepository.Delete(maestroDetalle);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<PaginacionDto<MaestroDetalleDto>> GetMaestroDetallePaginados(FiltroMaestroDetalleParametroDto filtroMaestroDetalleParametroDto)
        {
            IQueryable<MaestroDetalle> consulta = await _maestroDetalleRepository.GetQueryable();

            if (filtroMaestroDetalleParametroDto.IdMatricula.HasValue)
            {
                consulta = consulta.Where(a => a.IdMatricula == filtroMaestroDetalleParametroDto.IdMatricula.Value);
            }

            if (filtroMaestroDetalleParametroDto.IdCurso.HasValue)
            {
                consulta = consulta.Where(a => a.IdCurso == filtroMaestroDetalleParametroDto.IdCurso.Value);
            }

            if (filtroMaestroDetalleParametroDto.Acreditado != 0)
            {
                consulta = consulta.Where(a => a.Acreditado == filtroMaestroDetalleParametroDto.Acreditado);
            }

            if (!string.IsNullOrWhiteSpace(filtroMaestroDetalleParametroDto.Estado))
            {
                consulta = consulta.Where(a => a.Estado.Contains(filtroMaestroDetalleParametroDto.Estado));
            }

            int totalMaestroDetalle = consulta.Count();
            // Obtener el totoal de paginas Math.Ceiling 
            int totalPages = (int)Math.Ceiling((double)totalMaestroDetalle / filtroMaestroDetalleParametroDto.Limite);
            var excluirElementos = filtroMaestroDetalleParametroDto.Limite * filtroMaestroDetalleParametroDto.Pagina;
            var maestroDetallesPaginados = await _maestroDetalleRepository.GetPaginado(consulta, filtroMaestroDetalleParametroDto.Limite, excluirElementos);
            var maestroDetallesDto = _mapper.Map<List<MaestroDetalleDto>>(maestroDetallesPaginados);
            var paginacionDto = new PaginacionDto<MaestroDetalleDto>
            {
                TotalItems = totalMaestroDetalle,
                PaginaActual = filtroMaestroDetalleParametroDto.Pagina + 1,
                TotalPaginas = totalPages,
                Items = maestroDetallesDto
            };
            return paginacionDto;
        }
    }
}
