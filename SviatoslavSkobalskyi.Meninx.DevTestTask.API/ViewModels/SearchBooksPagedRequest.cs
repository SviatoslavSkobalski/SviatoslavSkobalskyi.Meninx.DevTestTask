namespace SviatoslavSkobalskyi.Meninx.DevTestTask.API.ViewModels
{
    public class SearchBooksPagedRequest
    {
        public string FreeSearchCriteria { get; set; }
        public SortingViewModel Sorting { get; set; }
        public PaginationViewModel Pagination { get; set; }
    }
}
