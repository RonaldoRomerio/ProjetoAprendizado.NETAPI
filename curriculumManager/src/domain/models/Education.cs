using curriculumManager.src.domain.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace curriculumManager.src.domain.models
{
    public class Education : EntityBase
    {
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public String NameSchool { get; set; }
        public Graduation Graduation { get; set; }
        public int StartYear { get; set; }
        public int EndYear { get; set; }
        public int Course { get; set; }

        public Education() { }
        public Education(string nameSchool, Graduation graduation, int startYear, int endYear, int course)
        {
            NameSchool = nameSchool;
            Graduation = graduation;
            StartYear = startYear;
            EndYear = endYear;
            Course = course;
        }
    }
    
}
