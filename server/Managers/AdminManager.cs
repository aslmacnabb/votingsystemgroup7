using server.IAccessors;
using server.IManagers;
using server.Managers;
using server.Accessors;

namespace server.Managers
{
    public class AdminManager : IAdminManager
    {
        private IAdminProfileAccessor apa;
        private IUserAccessor ua;

        public AdminManager()
        {
            apa = new AdminProfileAccessor();
            ua = new UserAccessor();
        }

        public string AddElection(string username, string password, string title)
        {
            UserManager um = new UserManager(ua);
            if (um.Authenticate(username, password) == true)
            {
                    int userid = ua.GetIdFromUsername(username);
                    int adminid = apa.GetAdminIdFromUserId(userid);
                    apa.AddElection(adminid, title);
                    return "Election " + title + " successfully added!";
            }
            else
            {
                return "Error: your username and password are not valid!";
            }
        }
    }
}
