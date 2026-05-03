using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using server.Managers;
using server.Accessors;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BallotController : ControllerBase
    {
        [HttpGet("ballotdate")]
        public DateTime GetBallotDate(string username, string password, string election_name)
        {
            UserManager um = new UserManager();
            UserAccessor ua = new UserAccessor();
            VoterProfileAccessor va = new VoterProfileAccessor();
            ElectionAccessor ea = new ElectionAccessor();
            BallotAccessor ba = new BallotAccessor();
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
        
        [HttpGet("measuredecision")]
        public string GetMeasureDecision(string username, string password, string election_name)
        {
            UserManager um = new UserManager();
            UserAccessor ua = new UserAccessor();
            VoterProfileAccessor va = new VoterProfileAccessor();
            ElectionAccessor ea = new ElectionAccessor();
            BallotAccessor ba = new BallotAccessor();
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
        
        [HttpGet("measurefromelection")]
        public List<string> GetMeasuresFromElection(string election_name)
        {
            ElectionAccessor ea = new ElectionAccessor();
            BallotAccessor ba = new BallotAccessor();
            int electionid = ea.GetElectionIdFromElectionName(election_name);
            return ba.GetMeasuresFromElection(electionid);
        }
        
        [HttpGet("allelections")]
        public List<string> GetAllElectionNames()
        {
            ElectionAccessor ea = new ElectionAccessor();
            return ea.GetAllElectionNames();
        }
        
        [HttpPut("measuredecision")]
        public void SetMeasureDecision(string username, string password, string election_name, string new_value)
        {
            UserManager um = new UserManager();
            UserAccessor ua = new UserAccessor();
            VoterProfileAccessor va = new VoterProfileAccessor();
            ElectionAccessor ea = new ElectionAccessor();
            BallotAccessor ba = new BallotAccessor();
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
        
        [HttpPut("ballotdate")]
        public void SetBallotDate(string username, string password, string election_name, DateTime new_value)
        {
            UserManager um = new UserManager();
            UserAccessor ua = new UserAccessor();
            VoterProfileAccessor va = new VoterProfileAccessor();
            ElectionAccessor ea = new ElectionAccessor();
            BallotAccessor ba = new BallotAccessor();
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

    }
}
