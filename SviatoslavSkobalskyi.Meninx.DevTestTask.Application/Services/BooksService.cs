using AutoMapper;
using SviatoslavSkobalskyi.Meninx.DevTestTask.Application.DTO;
using SviatoslavSkobalskyi.Meninx.DevTestTask.Core.Entities;
using SviatoslavSkobalskyi.Meninx.DevTestTask.Core.Repositories;

namespace SviatoslavSkobalskyi.Meninx.DevTestTask.Application.Services
{
    public class BooksService : IBooksService
    {
        private readonly IBookRepository _booksRepository;
        private readonly IMapper _mapper;

        public BooksService(IBookRepository booksRepository, IMapper mapper)
        {
            _booksRepository = booksRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<BookDTO>> GetBooksAsync(string freeSearchCriteria, SortingDTO sorting)
        {
            return _mapper.Map<IEnumerable<BookDTO>>(await _booksRepository.GetBooksAsync(freeSearchCriteria, sorting.SortBy.ToString(), sorting.Order.ToString()));
        }

        public async Task<IEnumerable<BookDTO>> GetBooksPagedAsync(string freeSearchCriteria, SortingDTO sorting, PaginationDTO pagination)
        {
            return _mapper.Map<IEnumerable<BookDTO>>(await _booksRepository.GetBooksPagedAsync(freeSearchCriteria, pagination.Page, pagination.PageSize, sorting.SortBy.ToString(), sorting.Order.ToString()));
        }
        public async Task<BookDTO> GetBookAsync(int id)
        {
            return _mapper.Map<BookDTO>(await _booksRepository.GetBookByIdAsync(id));
        }

        public async Task CreateBookAsync(BookDTO book)
        {
            await _booksRepository.CreateBookAsync(_mapper.Map<Book>(book));
        }

        public async Task DeleteBookAsync(int id)
        {
            await _booksRepository.DeleteBookAsync(id);
        }

        public async Task UpdateBookAsync(BookDTO book)
        {
            await _booksRepository.UpdateBookAsync(_mapper.Map<Book>(book));
        }
    }
}
