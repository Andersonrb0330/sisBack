using AutoMapper;
using Domain.Entity;

namespace Application.Dtos.Response
{
    public class AulaDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }

    public class AulaProfile : Profile
    {
        public AulaProfile()
        {
            CreateMap<Aula, AulaDto>();
        }
    }
}
