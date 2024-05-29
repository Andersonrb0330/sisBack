using AutoMapper;
using Domain.Entity;

namespace Application.Dtos.Response
{
    public class CategoriaDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public CategoriaDto() { }
    }

    public class CategoriaProfile : Profile
    { 
        public CategoriaProfile()
        {
            CreateMap<Categoria, CategoriaDto>();
        }
    }
}
