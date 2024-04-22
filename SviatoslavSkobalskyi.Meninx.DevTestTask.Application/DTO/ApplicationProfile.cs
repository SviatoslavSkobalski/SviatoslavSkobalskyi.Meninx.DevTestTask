using AutoMapper;
using SviatoslavSkobalskyi.Meninx.DevTestTask.Core.Entities;

namespace SviatoslavSkobalskyi.Meninx.DevTestTask.Application.DTO
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<BookDTO, Book>().ReverseMap();
        }
    }
}
