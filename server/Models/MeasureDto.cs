namespace server.Models
{
    public class MeasureDto
    {
        public int MeasureId { get; set; }
        public int ElectionId { get; set; }
        public string MeasureTitle { get; set; }
        public string MeasureText { get; set; }
        public string YesDescription { get; set; }
        public string NoDescription { get; set; }
        public int DisplayOrder { get; set; }
    }
}
