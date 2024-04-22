using Microsoft.EntityFrameworkCore;
using SviatoslavSkobalskyi.Meninx.DevTestTask.Core.Entities;
using SviatoslavSkobalskyi.Meninx.DevTestTask.Core.Repositories;

namespace SviatoslavSkobalskyi.Meninx.DevTestTask.Persistance.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<Book> _books;

        public BookRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _books = dbContext.Books;
        }
        public Task<List<Book>> GetBooksAsync(string freeSearchCriteria, string sortingColumn, string sortingDirection)
        {
            var query = $@"
                EXEC GetAllBooksFilteredSortedPaged
                    @SEARCH_TEXT = {freeSearchCriteria},
                    @SORT_COLUMN_NAME = {sortingColumn},
                    @SORT_COLUMN_DIRECTION = {sortingDirection},
                    @PAGE_SIZE = {100}";
            return _books.FromSqlInterpolated($"EXEC [dbo].[GetAllBooksFilteredSortedPaged] {freeSearchCriteria}, {sortingColumn}, {sortingDirection}").ToListAsync();
        }

        public async Task<List<Book>> GetBooksPagedAsync(string freeSearchCriteria, int pageNumber, int pageSize, string sortingColumn, string sortingDirection)
        {
            var query = $@"
                EXEC GetAllBooksFilteredSortedPaged
                    @SEARCH_TEXT = {freeSearchCriteria},
                    @SORT_COLUMN_NAME = {sortingColumn},
                    @SORT_COLUMN_DIRECTION = {sortingDirection},
                    @START_INDEX = {pageNumber*pageSize},
                    @PAGE_SIZE = {pageSize}";
            return await _books.FromSqlInterpolated($"EXEC [dbo].[GetAllBooksFilteredSortedPaged] {freeSearchCriteria}, {pageNumber}, {pageSize}, {sortingColumn}, {sortingDirection}").ToListAsync();
        }
        public async Task CreateBookAsync(Book book)
        {
            _books.Add(book);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteBookAsync(int id)
        {
            var book = await _books.FirstOrDefaultAsync(x => x.Id == id);

            if (book != null)
            {
                _books.Remove(book);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            return await _books.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateBookAsync(Book book)
        {
            _books.Update(book);
            await _dbContext.SaveChangesAsync();
        }
    }
}
