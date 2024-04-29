using LibraryAPI.Entity;

namespace LibraryAPI.Services.Interface
{
    public interface IAuthorService
    {
        List<Authors> GetAuthorsAll();
        int InsertAuthor(Authors authors);
    }
}