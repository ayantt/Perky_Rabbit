using LibraryAPI.Entity;
using LibraryAPI.ViewModels;

namespace LibraryAPI.Services.Interface
{
    public interface IBookService
    {
        List<Books> GetBooksAll();
        Books GetBooksById(int id);
        Task<List<BookDetailVM>> GetBooksWithDetails();
        int InsertBook(Books books);
        int UpdateBook(Books books);
    }
}