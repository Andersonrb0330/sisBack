using Application.Dtos.Response;
using Application.Dtos.Resquest;
using Application.Interfaces;
using AutoMapper;
using Domain.Entity;
using Domain.IRepositories;
using FluentValidation;

namespace Application.Implementaciones
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IValidator<CategoriaParametroDto> _validatorCategoria;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoriaService(
             ICategoriaRepository categoriaRepository,
             IValidator<CategoriaParametroDto> validator,
             IUnitOfWork unitOfWork,
             IMapper mapper)
        { 
           _categoriaRepository = categoriaRepository;
           _validatorCategoria = validator;
           _unitOfWork = unitOfWork;
           _mapper = mapper;
            
        }

        public async Task<List<CategoriaDto>> GetAll()
        {
            List<Categoria> categoria = await _categoriaRepository.GetAll();
            List<CategoriaDto> categoriaDto = _mapper.Map<List<CategoriaDto>>(categoria);
            return categoriaDto;
        }

        public async Task<CategoriaDto> GetById(int id)
        {
            Categoria categoria = await _categoriaRepository.GetById(id);
            CategoriaDto categoriaDto = _mapper.Map<CategoriaDto>(categoria);
            return categoriaDto;
        }

        public async Task<int> Create(CategoriaParametroDto categoriaParametroDto)
        {
            var validationResult = _validatorCategoria.Validate(categoriaParametroDto);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            Categoria categoria = new Categoria
            {
                Nombre = categoriaParametroDto.Nombre,
            };

            await _categoriaRepository.Create(categoria);   
            await _unitOfWork.SaveChangesAsync();
            return categoria.Id;
        }

        public async Task Update(CategoriaParametroDto categoriaParametroDto)
        {
            Categoria categoria = await _categoriaRepository.GetById(categoriaParametroDto.Id);
            if (categoria == null)
            {
                throw new Exception($"No existe Categoria con este ID: {categoriaParametroDto.Id}");
            }

            categoria.Nombre = categoriaParametroDto.Nombre;

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            Categoria categoria = await _categoriaRepository.GetById(id);
            if (categoria == null)
            {
                throw new Exception($"No existe Categoria con este ID: {id}");
            }

            _categoriaRepository.Delete(categoria);
            await _unitOfWork.SaveChangesAsync();

        }

        public async Task<PaginacionDto<CategoriaDto>> GetCategoriaPaginados(FiltroCategoriaParametroDto filtroCategoriaParametroDto)
        {
            IQueryable<Categoria> consulta = await _categoriaRepository.GetQueryable();

            // Aplicar filtros
            if (!string.IsNullOrWhiteSpace(filtroCategoriaParametroDto.Nombre))
            {
                consulta = consulta.Where(a => a.Nombre.Contains(filtroCategoriaParametroDto.Nombre));
            }

            int totalCategoria = consulta.Count();
            // Obtener el totoal de paginas Math.Ceiling 
            int totalPages = (int)Math.Ceiling((double)totalCategoria / filtroCategoriaParametroDto.Limite);
            var excluirElementos = filtroCategoriaParametroDto.Limite * filtroCategoriaParametroDto.Pagina;
            var categoriaPaginados = await _categoriaRepository.GetPaginado(consulta, filtroCategoriaParametroDto.Limite, excluirElementos);
            var categoriaDto = _mapper.Map<List<CategoriaDto>>(categoriaPaginados);
            var paginacionDto = new PaginacionDto<CategoriaDto>
            {
                TotalItems = totalCategoria,
                PaginaActual = filtroCategoriaParametroDto.Pagina + 1,
                TotalPaginas = totalPages,
                Items = categoriaDto
            };
            return paginacionDto;
        }
    }
}
