using LibraryAPI.Entity;
using LibraryAPI.Models;
using LibraryAPI.ViewModels;

namespace LibraryAPI.Services.Interface
{
    public interface IMemberService
    {
        List<Members> GetMembersAll();
        int InsertMembers(Members members);
        LoginResVM LoginCheck(LoginVM loginModel);
    }
}