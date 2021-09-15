using AspNetSandBox.DTOs;
using AspNetSandBox.Models;
using AutoMapper;

namespace AspNetSandBox.Profiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<CreateBookDto, Book>();
        }
    }
}
