using SviatoslavSkobalskyi.Meninx.DevTestTask.Application.DTO;

namespace SviatoslavSkobalskyi.Meninx.DevTestTask.Application.Services
{
    public interface IBooksService
    {
        Task<IEnumerable<BookDTO>> GetBooksAsync(string freeSearchCriteria, SortingDTO sorting);
        Task<IEnumerable<BookDTO>> GetBooksPagedAsync(string freeSearchCriteria, SortingDTO sorting, PaginationDTO pagination);
        Task<BookDTO> GetBookAsync(int id);
        Task CreateBookAsync(BookDTO book);
        Task UpdateBookAsync(BookDTO book);
        Task DeleteBookAsync(int id);
    }
}