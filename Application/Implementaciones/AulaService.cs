using Application.Dtos.Response;
using Application.Dtos.Resquest;
using Application.Interfaces;
using AutoMapper;
using Domain.Entity;
using Domain.IRepositories;
using FluentValidation;

namespace Application.Implementaciones
{
    public class AulaService : IAulaService
    {
        private readonly IAulaRepository _aulaRepository;
        private readonly IValidator<AulaParametroDto> _validatorAula;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AulaService(
            IAulaRepository aulaRepository,
            IValidator<AulaParametroDto> validator,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _aulaRepository = aulaRepository;
            _validatorAula = validator;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task<List<AulaDto>> GetAll()
        {
            List<Aula> aula = await _aulaRepository.GetAll();
            List<AulaDto> aulaDto = _mapper.Map<List<AulaDto>>(aula);
            return aulaDto;
        }

        public async Task<AulaDto> GetById(int id)
        {
            Aula aula = await _aulaRepository.GetById(id);
            AulaDto aulaDto = _mapper.Map<AulaDto>(aula);
            return aulaDto;
        }

        public async Task<int> Create(AulaParametroDto aulaParametroDto)
        {
            var validationResult = _validatorAula.Validate(aulaParametroDto);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            Aula aula = new Aula
            {
                Nombre = aulaParametroDto.Nombre,
            };

            await _aulaRepository.Create(aula);
            await _unitOfWork.SaveChangesAsync();
            return aula.Id;

        }

        public async Task Update(AulaParametroDto aulaParametroDto)
        {
            Aula aula = await _aulaRepository.GetById(aulaParametroDto.Id);
            if (aula == null)
            {
                throw new Exception($"No existe Aula con este ID: {aulaParametroDto.Id}");
            }

            aula.Nombre = aulaParametroDto.Nombre;

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            Aula aula = await _aulaRepository.GetById(id);
            if (aula == null)
            {
                throw new Exception($"No existe Aula con este ID: {id}");
            }

            _aulaRepository.Delete(aula);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<PaginacionDto<AulaDto>> GetAulaPaginados(FiltroAulaParametroDto filtroAulaParametroDto)
        {
            IQueryable<Aula> consulta = await _aulaRepository.GetQueryable();

            // Aplicar filtros
            if (!string.IsNullOrWhiteSpace(filtroAulaParametroDto.Nombre))
            {
                consulta = consulta.Where(a => a.Nombre.Contains(filtroAulaParametroDto.Nombre));
            }

            int totalAula = consulta.Count();
            // Obtener el totoal de paginas Math.Ceiling 
            int totalPages = (int)Math.Ceiling((double)totalAula / filtroAulaParametroDto.Limite);
            var excluirElementos = filtroAulaParametroDto.Limite * filtroAulaParametroDto.Pagina;
            var aulaPaginados = await _aulaRepository.GetPaginado(consulta, filtroAulaParametroDto.Limite, excluirElementos);
            var aulaDto = _mapper.Map<List<AulaDto>>(aulaPaginados);
            var paginacionDto = new PaginacionDto<AulaDto>
            {
                TotalItems = totalAula,
                PaginaActual = filtroAulaParametroDto.Pagina + 1,
                TotalPaginas = totalPages,
                Items = aulaDto
            };
            return paginacionDto;

        }
    }
}
