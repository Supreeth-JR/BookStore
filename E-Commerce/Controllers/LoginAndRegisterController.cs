using Common;
using Common.CommonModel;
using Common.LoginAndLogout;
using E_Commerce.Middleware;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace E_Commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginAndRegisterController : Controller
    {
        private readonly IConfiguration configuration;
        public LoginAndRegisterController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [HttpPost]
        [Route("UserLogin")]
        public IActionResult UserLogin(UserLoginInput ObjInput)
        {
            HttpContext httpContext = HttpContext;
            IActionResult ObjResponse = Unauthorized();
            UserLoginOutput ObjOutput = new UserLogin(configuration, httpContext).GetUserLogin(ObjInput);
            if (!string.IsNullOrEmpty(ObjOutput?.StrEmail))
            {
                return Ok(new
                {
                    UserId = ObjOutput.IntUserID,
                    Toke = ObjOutput.StrToken,
                    Session = ObjOutput.strSession,
                    role = ObjOutput.StrUserRole
                });
            }
            return ObjResponse = Ok(new { message = "InValid Credenticals" });

        }
        [HttpPost]
        [Route("UserRegister")]
        public IActionResult UserRegister(UserRegistrationInput ObjInput)
        {
            return Ok(new UserRegistration().GetUserRegistration(ObjInput));
        }
        [HttpPost]
        [Route("UserLogout")]        
        public IActionResult UserLogout(LogoutInput ObjInput)
        {
            return Ok(new UserLogout().GetLogout(ObjInput));
        }
        [HttpPost]
        [Route("GetUserNameByUID")]
        //[ServiceFilter(typeof(ECommerceAuth))]
        public IActionResult GetUserNameByUID(UserNameInput ObjInput)
        {
           return Ok(new UserNameByUID().GetUserByUID(ObjInput));
        }
    }
}
