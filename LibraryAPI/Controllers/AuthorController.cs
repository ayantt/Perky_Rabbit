using LibraryAPI.Entity;
using LibraryAPI.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [ApiController]
    public class AuthorController : Controller
    {
        private readonly IAuthorService authorsSservice;
        public AuthorController(IAuthorService authorsSservice)
        {
            this.authorsSservice = authorsSservice;
        }

        [HttpGet]
        [Route("GetAuthors")]
        public List<Authors> Get()
        {
            return authorsSservice.GetAuthorsAll();
        }

        [HttpPost]
        [Route("InsertAuthors")]
        public int Insert(Authors authors)
        {
            return authorsSservice.InsertAuthor(authors);
        }
    }
}
