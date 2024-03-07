using curriculumManager.src.domain.Enum;

namespace curriculumManager.src.domain.dtos.education
{
    public class EducationInsert
    {
        public int CustomerId { get; set; }
        public String NameSchool { get; set; }
        public Graduation Graduation { get; set; }
        public int StartYear { get; set; }
        public int EndYear { get; set; }
        public int Course { get; set; }
    }
}
