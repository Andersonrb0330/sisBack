using AutoMapper;
using Domain.Entity;

namespace Application.Dtos.Response
{
    public class LoginDto
    {
        public int Id { get; set; }
        public string Email { get; set; }

        public LoginDto() { }   
    }

    public class LoginProfile : Profile
    {
        public LoginProfile()
        {
            CreateMap<Login, LoginDto>();
        }
    }


}
