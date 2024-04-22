using SviatoslavSkobalskyi.Meninx.DevTestTask.Application.DTO.Enums;

namespace SviatoslavSkobalskyi.Meninx.DevTestTask.Application.DTO
{
    public class SortingDTO
    {
        public FieldsDTO SortBy { get; set; }
        public SortOrderDTO Order { get; set; }
    }
}
