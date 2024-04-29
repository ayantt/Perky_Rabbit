using LibraryAPI.Entity;
using LibraryAPI.Repository.Interface;
using LibraryAPI.Services.Interface;
using LibraryAPI.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Services
{
    public class BookService : IBookService
    {
        private readonly IBooksRepo _booksRepo;
        private readonly IAuthorsRepo _authorsRepo;

        public BookService(IBooksRepo booksRepo, IAuthorsRepo authorsRepo)
        {
            _booksRepo = booksRepo ?? throw new ArgumentNullException(nameof(booksRepo));
            _authorsRepo = authorsRepo ?? throw new ArgumentNullException(nameof(authorsRepo));
        }

        public List<Books> GetBooksAll()
        {
            return _booksRepo.GetBooksAll();
        }

        public Books GetBooksById(int id)
        {
            return _booksRepo.GetBooksById(id);
        }

        public int InsertBook(Books books)
        {
            return _booksRepo.InsertBook(books);
        }

        public int UpdateBook(Books books)
        {
            return _booksRepo.UpdateBook(books);
        }

        public Task<List<BookDetailVM>> GetBooksWithDetails()
        {
            return _booksRepo.GetBookDetails();
        }
    }
}
