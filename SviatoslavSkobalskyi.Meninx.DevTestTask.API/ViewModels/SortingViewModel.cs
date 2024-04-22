using SviatoslavSkobalskyi.Meninx.DevTestTask.API.ViewModels.Enums;

namespace SviatoslavSkobalskyi.Meninx.DevTestTask.API.ViewModels
{
    public class SortingViewModel
    {
        public FieldsViewModel SortBy { get; set; }
        public SortOrderViewModel Order { get; set; }
    }
}
