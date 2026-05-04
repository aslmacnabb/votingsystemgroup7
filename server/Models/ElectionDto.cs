namespace server.Models
{
    public class ElectionDto
    {
        public int ElectionId { get; set; }
        public string ElectionName { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsPublished { get; set; }
        public List<OfficeDto> Offices { get; set; }
        public List<MeasureDto> Measures { get; set; }
    }
}
