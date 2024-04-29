using LibraryAPI.Entity;
using LibraryAPI.Repository.Interface;
using LibraryAPI.Utility;
using static System.Reflection.Metadata.BlobBuilder;

namespace LibraryAPI.Repository
{
    public class BorrowedBooksRepo : IBorrowedBooksRepo
    {
        private APIDBContext dbContext;

        public BorrowedBooksRepo(APIDBContext dbContext)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public int Insert(BorrowedBooks borrowed)
        {
            try
            {
                dbContext.BorrowedBooks.Add(borrowed);
                dbContext.SaveChanges();
                return 0;
            }
            catch (Exception)
            {
                return 1;
            }
        }

        public int Update(BorrowedBooks borrowed)
        {
            try
            {
                dbContext.BorrowedBooks.Update(borrowed);
                dbContext.SaveChanges();
                return 0;
            }
            catch (Exception)
            {
                return 1;
            }
        }

        public BorrowedBooks? GetBorrowedBooks(int memberId, int bookId) 
        {
            try
            {
                BorrowedBooks book = dbContext.BorrowedBooks.Where(x => x.MemberId == memberId && x.BookId == bookId && x.Status == "Borrowed").OrderBy(x => x.BorrowDate).FirstOrDefault();
                return book == null ? null : book;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
