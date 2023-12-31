using CleanArchitecture1.Infrastructure.Security;
using CleanArchitecture1.Models.Main;
using CleanArchitecture1.Models.ViewModels;
using CleanArchitecture1.UnitOfWork.Main;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RxWeb.Core.Security.Cryptography;
using RxWeb.Core.Security.Filters;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture1.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private ILoginUow LoginUow { get; set; }
        private IApplicationTokenProvider ApplicationTokenProvider { get; set; }
        private IPasswordHash PasswordHash { get; set; }

        public AuthenticationController(ILoginUow loginUow, IApplicationTokenProvider tokenProvider, IPasswordHash passwordHash)
        {
            this.LoginUow = loginUow;
            ApplicationTokenProvider = tokenProvider;
            PasswordHash = passwordHash;
        }

        [HttpGet("hello")]
 

        public async Task<IActionResult> Get()
        {
            var token = await ApplicationTokenProvider.GetTokenAsync(new vUser { UserId = 0, ApplicationTimeZoneName = string.Empty, LanguageCode = string.Empty });
            return Ok(token);
        }
        [HttpGet]
        public IActionResult getdata()
        {
            return Ok("hello");
        }

        [HttpPost]
        public async Task<IActionResult> Post(AuthenticationModel authentication)
        {
            var user = await LoginUow.Repository<vUser>().SingleOrDefaultAsync(t => t.UserName == authentication.UserName && !t.LoginBlocked);
                //if (user != null )
                //{
                //    var token = await ApplicationTokenProvider.GetTokenAsync(user);
                //    return Ok("h");
                //}
           
                return Ok("hello");
        }
    }
}

