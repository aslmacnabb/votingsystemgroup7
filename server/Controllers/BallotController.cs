using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using server.Managers;
using server.Accessors;
using server.Models;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BallotController : ControllerBase
    {
        [HttpGet("elections")]
        public ActionResult<List<ElectionDto>> GetAllElections()
        {
            try
            {
                ElectionAccessor ea = new ElectionAccessor();
                List<ElectionDto> elections = ea.GetAllElections();
                if (elections == null || elections.Count == 0)
                {
                    return Ok(new List<ElectionDto>());
                }
                return Ok(elections);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error retrieving elections: " + ex.Message });
            }
        }

        [HttpGet("election/{id}")]
        public ActionResult<ElectionDto> GetElection(int id)
        {
            try
            {
                ElectionAccessor ea = new ElectionAccessor();
                ElectionDto election = ea.GetElectionById(id);
                if (election == null)
                {
                    return NotFound(new { message = "Election not found" });
                }
                return Ok(election);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error retrieving election: " + ex.Message });
            }
        }

        [HttpPost("submit")]
        public ActionResult<object> SubmitVotes([FromBody] VoteSubmissionRequest request)
        {
            try
            {
                if (string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Password))
                {
                    return BadRequest(new { message = "Username and password are required" });
                }

                UserManager um = new UserManager();
                if (!um.Authenticate(request.Username, request.Password))
                {
                    return Unauthorized(new { message = "Invalid credentials" });
                }

                UserAccessor ua = new UserAccessor();
                VoterProfileAccessor va = new VoterProfileAccessor();
                BallotAccessor ba = new BallotAccessor();
                VoteAccessor voa = new VoteAccessor();

                int userId = ua.GetIdFromUsername(request.Username);
                int voterId = va.GetVoterIdFromUserId(userId);
                int ballotId = ba.GetBallotId(request.ElectionId, voterId);

                if (ballotId == -1)
                {
                    return BadRequest(new { message = "Ballot not found for this election" });
                }

                // Submit all votes
                foreach (var vote in request.Votes)
                {
                    voa.AddVote(ballotId, vote.CandidateId, vote.MeasureId, vote.OfficeId, vote.SelectionValue);
                }

                // Mark ballot as submitted
                ba.SetMeasureDecision(ballotId, "submitted");
                ba.SetBallotDate(ballotId, DateTime.Now);

                return Ok(new { message = "Votes submitted successfully", ballotId = ballotId });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error submitting votes: " + ex.Message });
            }
        }

        [HttpGet("history")]
        public ActionResult<List<dynamic>> GetVotingHistory(string username, string password)
        {
            try
            {
                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    return BadRequest(new { message = "Username and password are required" });
                }

                UserManager um = new UserManager();
                if (!um.Authenticate(username, password))
                {
                    return Unauthorized(new { message = "Invalid credentials" });
                }

                UserAccessor ua = new UserAccessor();
                VoteAccessor va = new VoteAccessor();

                int userId = ua.GetIdFromUsername(username);
                List<dynamic> votes = va.GetUserVotes(userId);

                return Ok(votes);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error retrieving voting history: " + ex.Message });
            }
        }

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
                return new DateTime(2000, 1, 1, 1, 1, 1);
            }
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
    }

    public class VoteSubmissionRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int ElectionId { get; set; }
        public List<VoteData> Votes { get; set; }
    }

    public class VoteData
    {
        public int? CandidateId { get; set; }
        public int? MeasureId { get; set; }
        public int? OfficeId { get; set; }
        public string SelectionValue { get; set; }
    }
}
