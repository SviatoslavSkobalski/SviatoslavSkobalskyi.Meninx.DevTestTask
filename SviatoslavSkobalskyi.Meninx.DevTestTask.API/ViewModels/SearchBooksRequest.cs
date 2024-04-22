namespace SviatoslavSkobalskyi.Meninx.DevTestTask.API.ViewModels
{
    public class SearchBooksRequest
    {
        public string FreeSearchCriteria { get; set; }
        public SortingViewModel Sorting { get; set; }
    }
}
