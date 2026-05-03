using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using server.Managers;
using server.Accessors;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        [HttpGet]
        public bool VeriftyLogin(string username, string password)
        {
            UserManager um = new UserManager();
            return um.Authenticate(username, password);
        }
        
    }
}