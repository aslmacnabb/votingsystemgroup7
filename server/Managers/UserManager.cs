using server.Accessors;
using server.IManagers;
using server.IAccessors;
namespace server.Managers
{
    public class UserManager : IUserManager
    {
        private IUserAccessor UserAccessor;

        public UserManager()
        {
            UserAccessor = new UserAccessor();
        }

        public bool Authenticate(string username, string password)
        {
            int id = UserAccessor.GetIdFromUsername(username);
            string expectedPassword = UserAccessor.GetString(id, "PasswordHash");
            if (password == expectedPassword)
            {
                return true;
            } else
            {
                return false;
            }
        }

        public string GetAccountType(string username, string password)
        {
            if (Authenticate(username, password) == true)
            {
                int id = UserAccessor.GetIdFromUsername(username);
                return UserAccessor.GetString(id, "AccountType");
            }
            else
            {
                return "Error: invalid username and password!";
            }
        }
    }
}
