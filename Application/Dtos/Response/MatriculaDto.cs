using AutoMapper;
using Domain.Entity;

namespace Application.Dtos.Response
{
    public class MatriculaDto
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Estado { get; set; }

        // F_K
        public  AlumnoDto Alumno { get; set; }
        public  LoginDto Login { get; set; }

        public MatriculaDto() { }
    }

    public class MatriculaProfile : Profile
    {
        public MatriculaProfile()
        {
            CreateMap<Matricula, MatriculaDto>();
        }
    }
}
