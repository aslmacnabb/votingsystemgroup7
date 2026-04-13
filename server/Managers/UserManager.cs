using server.Accessors;
using server.IManagers;

namespace server.Managers
{
    public class UserManager : IUserManager
    {
        public static string GetUserType(string username, string password)
        {
            if (UserAccessor.Authenticate(username, password))
            {
                return UserAccessor.GetUserType(username);
            } else
            {
                return "Invalid user";
            }
        }
    }
}