using LibraryAPI.Entity;
using LibraryAPI.Models;
using LibraryAPI.ViewModels;

namespace LibraryAPI.Repository.Interface
{
    public interface IMembersRepo
    {
        List<Members> GetMembersAll();
        int InsertMembers(Members Members);
        LoginResVM LoginCheck(LoginVM loginModel);
    }
}