using LibraryAPI.Entity;
using LibraryAPI.Services.Interface;
using LibraryAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [ApiController]
    public class BooksController : Controller
    {
        private readonly IBookService bookService;
        public BooksController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        [HttpGet]
        [Route("GetBooks")]
        public Task<List<BookDetailVM>> Get()
        {
            return bookService.GetBooksWithDetails();
        }

        [HttpPost]
        [Route("InsertBooks")]
        public int Insert(Books books)
        {
            return bookService.InsertBook(books);
        }
    }
}
