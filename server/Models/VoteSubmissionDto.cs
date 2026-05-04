namespace server.Models
{
    public class VoteSubmissionDto
    {
        public int ElectionId { get; set; }
        public List<Vote> Votes { get; set; }
    }

    public class Vote
    {
        public int? CandidateId { get; set; }
        public int? MeasureId { get; set; }
        public int? OfficeId { get; set; }
        public string SelectionValue { get; set; }
    }
}
