using AutoMapper;
using Library_Project.Dto;
using Library_Project.Models;

namespace Library_Project.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() 
        {
            //User
            CreateMap<User, UserDto>();

            //Book
            CreateMap<Book, BookDto>();
        }
    }
}
