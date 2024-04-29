using LibraryAPI.Entity;
using LibraryAPI.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [ApiController]
    public class BorBooksController : Controller
    {
        private readonly IBorrowBookService borrowed;
        public BorBooksController(IBorrowBookService borrowed)
        {
            this.borrowed = borrowed;
        }

        [HttpPost]
        [Route("InsertBorrow")]
        public int Insert(BorrowedBooks bb)
        {
            return borrowed.Insert(bb);
        }

        [HttpPost]
        [Route("BorrowReturn")]
        public int Return(BorrowedBooks bb)
        {
            return borrowed.Update(bb);
        }
    }
}
