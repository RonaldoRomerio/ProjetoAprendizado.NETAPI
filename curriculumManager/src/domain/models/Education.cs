using curriculumManager.src.domain.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace curriculumManager.src.domain.models
{
    public class Education : EntityBase
    {
        [Required]
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public string? NameSchool { get; set; }
        public Graduation? Graduation { get; set; }
        [Required]
        public int StartYear { get; set; }
        public int? EndYear { get; set; }
        public string? Course { get; set; }

        public Education() { }
        public Education(string nameSchool, Graduation graduation, int startYear, int endYear, string course)
        {
            NameSchool = nameSchool;
            Graduation = graduation;
            StartYear = startYear;
            EndYear = endYear;
            Course = course;
        }
    }
    
}
