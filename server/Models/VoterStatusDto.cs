namespace server.Models
{
    public class VoterStatusDto
    {
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool HasVoted { get; set; }
        public string SubmissionStatus { get; set; }
        public DateTime? CastAt { get; set; }
    }
}
