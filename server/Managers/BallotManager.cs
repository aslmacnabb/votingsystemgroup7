using server.Accessors;
using server.IAccessors;
using server.IManagers;

namespace server.Managers
{
    public class BallotManager : IBallotManager
    {
        private IBallotAccessor ba;
        private IUserAccessor ua;
        private IUserManager um;
        private IElectionAccessor ea;
        private IVoterProfileAccessor va;

        public BallotManager()
        {
            ba = new BallotAccessor();
            ua = new UserAccessor();
            um = new UserManager();
            ea = new ElectionAccessor();
            va = new VoterProfileAccessor();
        }

        public void SetMeasureDecision(string username, string password, string election_name, string new_value)
        {
            if (um.Authenticate(username, password) == true)
            {
                int userid = ua.GetIdFromUsername(username);
                int voterid = va.GetVoterIdFromUserId(userid);
                int electionid = ea.GetElectionIdFromElectionName(election_name);
                int ballotid = ba.GetBallotId(electionid, voterid);
                ba.SetMeasureDecision(ballotid, new_value);
            }
            else
            {
                Console.WriteLine("Error: your username and password are not valid!");
            }
        }

        public DateTime GetBallotDate(string username, string password, string election_name)
        {
            if (um.Authenticate(username, password) == true)
            {
                int userid = ua.GetIdFromUsername(username);
                int voterid = va.GetVoterIdFromUserId(userid);
                int electionid = ea.GetElectionIdFromElectionName(election_name);
                int ballotid = ba.GetBallotId(electionid, voterid);
                return ba.GetBallotDate(ballotid);
            }
            else
            {
                Console.WriteLine("Error: your username and password are not valid!");
                return new DateTime(2000, 1, 1, 1, 1, 1);
            }
        }

        public void SetBallotDate(string username, string password, string election_name, DateTime new_value)
        {
            if (um.Authenticate(username, password) == true)
            {
                int userid = ua.GetIdFromUsername(username);
                int voterid = va.GetVoterIdFromUserId(userid);
                int electionid = ea.GetElectionIdFromElectionName(election_name);
                int ballotid = ba.GetBallotId(electionid, voterid);
                ba.SetBallotDate(ballotid, new_value);
            }
            else
            {
                Console.WriteLine("Error: your username and password are not valid!");
            }
        }

        public string GetMeasureDecision(string username, string password, string election_name)
        {
            string output = "";
            if (um.Authenticate(username, password) == true)
            {
                int userid = ua.GetIdFromUsername(username);
                int voterid = va.GetVoterIdFromUserId(userid);
                int electionid = ea.GetElectionIdFromElectionName(election_name);
                int ballotid = ba.GetBallotId(electionid, voterid);
                output = ba.GetMeasureDecision(ballotid);
            }
            else
            {
                Console.WriteLine("Error: your username and password are not valid!");
            }
            return output;
        }

        public List<string> GetMeasuresFromElection(string election_name)
        {
            int electionid = ea.GetElectionIdFromElectionName(election_name);
            return ba.GetMeasuresFromElection(electionid);
        }

        /*
        Delegates to the election accessor to retrieve all election names.
        No authentication required. election names are publicly visible to voters.
        */
        public List<string> GetAllElectionNames()
        {
            /* Delegate directly to the election accessor.  no user context needed */
            return ea.GetAllElectionNames();
        }
    }
}
