using SviatoslavSkobalskyi.Meninx.DevTestTask.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SviatoslavSkobalskyi.Meninx.DevTestTask.Core.Repositories
{
    public interface IBookRepository
    {
        Task<List<Book>> GetBooksAsync(string freeSearchCriteria, string sortingColumn, string sortingDirection);
        Task<List<Book>> GetBooksPagedAsync(string freeSearchCriteria, int pageNumber, int pageSize, string sortingColumn, string sortingDirection);
        Task<Book> GetBookByIdAsync(int id);
        Task CreateBookAsync(Book book);
        Task UpdateBookAsync(Book book);
        Task DeleteBookAsync(int id);
    }
}
