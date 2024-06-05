using AutoMapper;
using Domain.Entity;

namespace Application.Dtos.Response
{
    public class CursoDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public CursoDto() { }
    }

    public class CursoProfile : Profile
    {
        public CursoProfile()
        {
            CreateMap<Curso, CursoDto>();
        }
    }
}
