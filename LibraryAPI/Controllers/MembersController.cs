using LibraryAPI.Entity;
using LibraryAPI.Models;
using LibraryAPI.Repository.Interface;
using LibraryAPI.Services.Interface;
using LibraryAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [ApiController]
    public class MembersController : Controller
    {
        private readonly IMemberService membersService;
        public MembersController(IMemberService membersService)
        {
            this.membersService = membersService;
        }

        [HttpGet]
        [Route("GetMembers")]
        public List<Members> Get()
        {
            return membersService.GetMembersAll();
        }

        [HttpPost]
        [Route("InsertMembers")]
        public int Insert(Members members)
        {
            return membersService.InsertMembers(members);
        }

        [HttpPost]
        [Route("Login")]
        public LoginResVM Login(LoginVM loginModel)
        {
            return membersService.LoginCheck(loginModel);
        }
    }
}
