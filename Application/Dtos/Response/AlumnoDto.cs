using AutoMapper;
using Domain.Entity;

namespace Application.Dtos.Response
{
    public class AlumnoDto
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Telefono { get; set; }
        public int Edad { get; set; }

        // F_k
        public  AulaDto Aula { get; set; }
        public  CategoriaDto Categoria { get; set; }
    
        public AlumnoDto() { }
    
    }

    public class AlumnoProfile : Profile
    {
        public AlumnoProfile() 
        {
            CreateMap<Alumno, AlumnoDto>();
        }
    }
}
