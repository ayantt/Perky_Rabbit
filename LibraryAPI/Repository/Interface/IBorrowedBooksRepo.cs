using LibraryAPI.Entity;

namespace LibraryAPI.Repository.Interface
{
    public interface IBorrowedBooksRepo
    {
        int Insert(BorrowedBooks borrowed);
        int Update(BorrowedBooks borrowed);
        BorrowedBooks GetBorrowedBooks(int memberId, int bookId);
    }
}