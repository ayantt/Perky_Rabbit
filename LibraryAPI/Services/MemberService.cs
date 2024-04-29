using LibraryAPI.Entity;
using LibraryAPI.Models;
using LibraryAPI.Repository.Interface;
using LibraryAPI.Services.Interface;
using LibraryAPI.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Services
{
    public class MemberService : IMemberService
    {
        private readonly IMembersRepo _membersRepo;

        public MemberService(IMembersRepo membersRepo)
        {
            _membersRepo = membersRepo ?? throw new ArgumentNullException(nameof(membersRepo));
        }

        public List<Members> GetMembersAll()
        {
            return _membersRepo.GetMembersAll();
        }

        public int InsertMembers(Members members)
        {
            return _membersRepo.InsertMembers(members);
        }

        public LoginResVM LoginCheck(LoginVM loginModel)
        {
            return _membersRepo.LoginCheck(loginModel);
        }
    }
}
