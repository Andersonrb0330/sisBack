using AutoMapper;
using Domain.Entity;

namespace Application.Dtos.Resquest
{
    public class AulaParametroDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public AulaParametroDto() { }

    }
}
