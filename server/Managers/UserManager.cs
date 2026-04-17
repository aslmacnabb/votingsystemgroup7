using server.Accessors;
using server.IManagers;
using server.IAccessors;
namespace server.Managers
{
    public class UserManager : IUserManager
    {
        private IUserAccessor UserAccessor;

        public UserManager(IUserAccessor userAccessor)
        {
            UserAccessor = userAccessor;
        }

        public string GetUserType(string username, string password)
        {
            if (UserAccessor.Authenticate(username, password))
            {
                return UserAccessor.GetUserType(username);
            }
            else
            {
                return "Invalid user";
            }
        }
    }
}