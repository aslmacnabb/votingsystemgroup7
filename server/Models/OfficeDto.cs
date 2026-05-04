namespace server.Models
{
    public class OfficeDto
    {
        public int OfficeId { get; set; }
        public int ElectionId { get; set; }
        public string OfficeTitle { get; set; }
        public string Description { get; set; }
        public int SeatsAvailable { get; set; }
        public int DisplayOrder { get; set; }
        public List<CandidateDto> Candidates { get; set; }
    }
}
