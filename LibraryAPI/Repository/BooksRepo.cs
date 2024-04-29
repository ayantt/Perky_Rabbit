using LibraryAPI.Entity;
using LibraryAPI.Repository.Interface;
using LibraryAPI.Utility;
using LibraryAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace LibraryAPI.Repository
{
    public class BooksRepo : IBooksRepo
    {
        private APIDBContext dbContext;

        public BooksRepo(APIDBContext dbContext)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public List<Books> GetBooksAll()
        {
            try
            {
                List<Books> books = dbContext.Books.ToList();
                return books;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Books GetBooksById(int id)
        {
            try
            {
                var book = dbContext.Books.Where(x => x.BookId == id).FirstOrDefault();
                return book;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public int InsertBook(Books books)
        {
            try
            {
                dbContext.Books.Add(books);
                dbContext.SaveChanges();
                return 0;
            }
            catch (Exception)
            {
                return 1;
            }
        }

        public int UpdateBook(Books books)
        {
            try
            {
                dbContext.Books.Update(books);
                dbContext.SaveChanges();
                return 0;
            }
            catch (Exception)
            {
                return 1;
            }
        }

        public async Task<List<BookDetailVM>> GetBookDetails() 
        {
            using (var command = dbContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "CALL GetBookDetails;";
                command.CommandType = CommandType.Text;
                dbContext.Database.OpenConnection();

                using (var result = await command.ExecuteReaderAsync())
                {
                    var bookDetails = new List<BookDetailVM>();
                    while (await result.ReadAsync())
                    {
                        bookDetails.Add(new BookDetailVM
                        {
                            BookId = result.GetInt32("BookId"),
                            Title = result.GetString("Title"),
                            AuthorName = result.GetString("AuthorName"),
                            PublishedDate = result.GetDateTime("PublishedDate"),
                            ISBN = result.GetString("ISBN"),
                            AvailableCopies = result.GetString("AvailableCopies")
                        });
                    }

                    return bookDetails;
                }
            }
        }
    }
}
