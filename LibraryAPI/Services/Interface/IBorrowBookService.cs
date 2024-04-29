using LibraryAPI.Entity;

namespace LibraryAPI.Services.Interface
{
    public interface IBorrowBookService
    {
        int Insert(BorrowedBooks borrowedBooks);
        int Update(BorrowedBooks borrowedBooks);
    }
}