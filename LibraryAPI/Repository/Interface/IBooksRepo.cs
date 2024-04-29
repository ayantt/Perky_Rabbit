using LibraryAPI.Entity;
using LibraryAPI.ViewModels;

namespace LibraryAPI.Repository.Interface
{
    public interface IBooksRepo
    {
        List<Books> GetBooksAll();
        Books GetBooksById(int id);
        int InsertBook(Books Books);
        int UpdateBook(Books Books);
        Task<List<BookDetailVM>> GetBookDetails();
    }
}