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
    }
}