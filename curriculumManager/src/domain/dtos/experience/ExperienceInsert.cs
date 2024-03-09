namespace curriculumManager.src.domain.dtos.experience
{
    public class ExperienceInsert
    {
        public int CustomerId { get; set; }
        public String Company { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public String Skills { get; set; }
    }
}
