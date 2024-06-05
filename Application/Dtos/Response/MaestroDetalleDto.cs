using AutoMapper;
using Domain.Entity;

namespace Application.Dtos.Response
{
    public class MaestroDetalleDto
    {
        public int Id { get; set; }
        public  MatriculaDto Matricula { get; set; }
        public  CursoDto Curso { get; set; }
        public int Acreditado { get; set; }
        public string Estado { get; set; }

        public MaestroDetalleDto() { }
    }

    public class MaestroDetalleProfile : Profile
    {
        public MaestroDetalleProfile()
        {
            CreateMap<MaestroDetalle, MaestroDetalleDto>();
        }
    }
}
