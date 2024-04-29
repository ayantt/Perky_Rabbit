using LibraryAPI.Entity;
using LibraryAPI.Repository.Interface;
using LibraryAPI.Utility;

namespace LibraryAPI.Repository
{
    public class AuthorsRepo : IAuthorsRepo
    {
        private APIDBContext dbContext;

        public AuthorsRepo(APIDBContext dbContext)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public List<Authors> GetAuthorsAll()
        {
            try
            {
                List<Authors> authors = dbContext.Authors.ToList();
                return authors;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int InsertAuthor(Authors authors)
        {
            try
            {
                dbContext.Authors.Add(authors);
                dbContext.SaveChanges();
                return 0;
            }
            catch (Exception)
            {
                return 1;
            }
        }
    }
}
