using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using server.Managers;
using server.Accessors;
using server.Models;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        
        
        [HttpPost("election")]
        public string AddElection(string username, string password, string title)
        {
            AdminManager am = new AdminManager();
            UserManager um = new UserManager();
            UserAccessor ua = new UserAccessor();
            AdminProfileAccessor apa = new AdminProfileAccessor();
            if (um.Authenticate(username, password) == true)
            {
                int userid = ua.GetIdFromUsername(username);
                int adminid = apa.GetAdminIdFromUserId(userid);
                apa.AddElection(adminid, title);
                am.AddBallots(username, password, title);
                return "Election " + title + " successfully added!";
            }
            else
            {
                return "Error: your username and password are not valid!";
            }
        }

        
        [HttpPost("measure")]
        public void AddMeasure(string username, string password, string election_name, string measure_title)
        {
            UserManager um = new UserManager();
            ElectionAccessor ea = new ElectionAccessor();
            MeasureAccessor ma = new MeasureAccessor();
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

        
        [HttpPost("ballot")]
        public void AddBallots(string username, string password, string election_name)
        {
            UserManager um = new UserManager();
            ElectionAccessor ea = new ElectionAccessor();
            VoterProfileAccessor va = new VoterProfileAccessor();
            BallotAccessor ba = new BallotAccessor();
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

        [HttpGet("election/{id}/voterstatus")]
        public ActionResult<List<VoterStatusDto>> GetVoterStatus(int id, string username, string password)
        {
            UserManager um = new UserManager();
            if (!um.Authenticate(username, password))
            {
                return Unauthorized();
            }

            if (um.GetAccountType(username, password) != "admin")
            {
                return Forbid();
            }

            BallotAccessor ba = new BallotAccessor();
            List<VoterStatusDto> statuses = ba.GetVoterVotingStatusByElection(id);
            return Ok(statuses);
        }
    }
}
