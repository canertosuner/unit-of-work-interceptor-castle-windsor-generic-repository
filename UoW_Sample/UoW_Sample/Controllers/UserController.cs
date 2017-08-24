using System.Net.Http;
using System.Web.Http;
using UoW_Sample.Request;
using UoW_Sample.Services;

namespace UoW_Sample.Controllers
{
    public class UserController : ApiController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public virtual HttpResponseMessage AddNewUser(AddNewUserRequest reqModel)
        {
             _userService.AddNewUser(reqModel);
            return Request.CreateResponse();
        }
    }
}
