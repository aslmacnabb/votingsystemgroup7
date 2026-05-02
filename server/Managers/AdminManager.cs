using server.Accessors;
using server.Accessors.IAccessors;
using server.Managers.IManagers;

namespace server.Managers
{
    public class AdminManager : IAdminManager
    {
        private IAdminProfileAccessor apa;
        private IUserAccessor ua;
        private IUserManager um;
        private IElectionAccessor ea;
        private IMeasureAccessor ma;
        private IVoterProfileAccessor va;
        private IBallotAccessor ba;

        public AdminManager()
        {
            apa = new AdminProfileAccessor();
            ua = new UserAccessor();
            um = new UserManager();
            ea = new ElectionAccessor();
            ma = new MeasureAccessor();
            va = new VoterProfileAccessor();
            ba = new BallotAccessor();
        }

        public string AddElection(string username, string password, string title)
        {
            if (um.Authenticate(username, password) == true)
            {
                    int userid = ua.GetIdFromUsername(username);
                    int adminid = apa.GetAdminIdFromUserId(userid);
                    apa.AddElection(adminid, title);
                    AddBallots(username, password, title);
                    return "Election " + title + " successfully added!";
            }
            else
            {
                return "Error: your username and password are not valid!";
            }
        }

        public void AddMeasure(string username, string password, string election_name, string measure_title)
        {
            if (um.Authenticate(username, password) == true)
            {
                if (um.GetAccountType(username, password) == "admin")
                {
                    int electionid = ea.GetElectionIdFromElectionName(election_name);
                    ma.AddMeasure(electionid, measure_title);
                }
                else
                {
                    Console.WriteLine("Error: your user is not an admin!");
                }
            }
            else
            {
                Console.WriteLine("Error: your username and password are not valid!");
            }
        }

        public void AddBallots(string username, string password, string election_name)
        {
            if (um.Authenticate(username, password) == true)
            {
                if (um.GetAccountType(username, password) == "admin")
                {
                    int electionid = ea.GetElectionIdFromElectionName(election_name);
                    int num_voters = va.GetNumberOfVoters();
                    for (int i = 1; i <= num_voters; i++) {
                        ba.AddBallot(i, electionid);
                    }
                }
                else
                {
                    Console.WriteLine("Error: your user is not an admin!");
                }
            }
            else
            {
                Console.WriteLine("Error: your username and password are not valid!");
            }
        }
    }
}
