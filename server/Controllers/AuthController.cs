using server.IControllers;
namespace server.Controllers
{
    public class AuthController : IAuthController
    {
        private IAuthController AuthController;

        public AuthController(IAuthController authController)
        {
            AuthController = authController;
        }

    }
}