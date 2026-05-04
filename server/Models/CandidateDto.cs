namespace server.Models
{
    public class CandidateDto
    {
        public int CandidateId { get; set; }
        public int OfficeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PartyAffiliation { get; set; }
        public string Biography { get; set; }
        public int DisplayOrder { get; set; }
    }
}
