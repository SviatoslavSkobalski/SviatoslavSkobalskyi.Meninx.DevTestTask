using AutoMapper;
using SviatoslavSkobalskyi.Meninx.DevTestTask.API.ViewModels.Enums;
using SviatoslavSkobalskyi.Meninx.DevTestTask.Application.DTO;
using SviatoslavSkobalskyi.Meninx.DevTestTask.Application.DTO.Enums;

namespace SviatoslavSkobalskyi.Meninx.DevTestTask.API.ViewModels
{
    public class ApiProfile : Profile
    {
        public ApiProfile()
        {
            CreateMap<BookViewModel, BookDTO>().ReverseMap();
            CreateMap<SortingViewModel, SortingDTO>().ReverseMap();
            CreateMap<PaginationViewModel, PaginationDTO>().ReverseMap();
            CreateMap<FieldsViewModel, FieldsDTO>().ReverseMap();
            CreateMap<SortOrderViewModel, SortOrderDTO>().ReverseMap();
        }
    }
}
