using LibraryAPI.Entity;
using LibraryAPI.Repository.Interface;
using LibraryAPI.Services.Interface;

namespace LibraryAPI.Services
{
    public class BorrowBookService : IBorrowBookService
    {
        private readonly IBookService _booksRepo;
        private readonly IBorrowedBooksRepo _borrowedBooksRepo;

        public BorrowBookService(IBookService booksRepo, IBorrowedBooksRepo borrowedBooksRepo)
        {
            _booksRepo = booksRepo ?? throw new ArgumentNullException(nameof(booksRepo));
            _borrowedBooksRepo = borrowedBooksRepo ?? throw new ArgumentNullException(nameof(borrowedBooksRepo));
        }

        public int Insert(BorrowedBooks borrowedBooks)
        {
            try
            {
                borrowedBooks.BorrowDate = DateTime.Now;
                borrowedBooks.Status = "Borrowed";
                _borrowedBooksRepo.Insert(borrowedBooks);

                var book = _booksRepo.GetBooksById(borrowedBooks.BookId);

                book.AvailableCopies -= 1;

                _booksRepo.UpdateBook(book);

                return 0;
            }
            catch (Exception)
            {
                return 1;
            }
            
        }

        public int Update(BorrowedBooks borrowedBooks)
        {
            BorrowedBooks borrowed = _borrowedBooksRepo.GetBorrowedBooks(borrowedBooks.MemberId, borrowedBooks.BookId);

            if (borrowed != null)
            {
                borrowed.ReturnDate = DateTime.Now;
                borrowed.Status = "Returned";
                _borrowedBooksRepo.Update(borrowed);

                var book = _booksRepo.GetBooksById(borrowed.BookId);

                book.AvailableCopies += 1;

                _booksRepo.UpdateBook(book);

                return 0;
            }
            else return 1;
        }
    }
}
