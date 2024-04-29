using LibraryAPI.Entity;
using LibraryAPI.Repository.Interface;
using LibraryAPI.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorsRepo _authorsRepo;

        public AuthorService(IAuthorsRepo authorsRepo)
        {
            _authorsRepo = authorsRepo ?? throw new ArgumentNullException(nameof(authorsRepo));
        }

        public List<Authors> GetAuthorsAll()
        {
            return _authorsRepo.GetAuthorsAll();
        }

        public int InsertAuthor(Authors authors)
        {
            return _authorsRepo.InsertAuthor(authors);
        }
    }
}
