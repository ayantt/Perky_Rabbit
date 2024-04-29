using LibraryAPI.Entity;

namespace LibraryAPI.Repository.Interface
{
    public interface IAuthorsRepo
    {
        int InsertAuthor(Authors authors);
        List<Authors> GetAuthorsAll();
    }
}
