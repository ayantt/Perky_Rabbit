using LibraryAPI.Entity;
using LibraryAPI.Models;
using LibraryAPI.Repository.Interface;
using LibraryAPI.Utility;
using LibraryAPI.ViewModels;

namespace LibraryAPI.Repository
{
    public class MembersRepo : IMembersRepo
    {
        private APIDBContext dbContext;

        public MembersRepo(APIDBContext dbContext)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public List<Members> GetMembersAll()
        {
            try
            {
                List<Members> members = dbContext.Members.ToList();
                return members;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int InsertMembers(Members members)
        {
            try
            {
                dbContext.Members.Add(members);
                dbContext.SaveChanges();
                return 0;
            }
            catch (Exception)
            {
                return 1;
            }
        }

        public LoginResVM LoginCheck(LoginVM loginModel)
        {
            LoginResVM result = new LoginResVM();
            result.LoginStatus = false;
            result.UserId = 0;
            try
            {
                var loginCheck = dbContext.Members.Where(x => x.Email == loginModel.UserName && x.Password == loginModel.Password).FirstOrDefault();
                if (loginCheck != null)
                {                    
                    result.LoginStatus = true;
                    result.UserId = loginCheck.MemberId;
                    return result;
                }
                else return result;
            }
            catch (Exception)
            {
                return result;
            }
        }
    }
}
