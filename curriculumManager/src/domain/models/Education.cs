using System.ComponentModel.DataAnnotations.Schema;

namespace curriculumManager.src.domain.models
{
    public class Education : EntityBase
    {
        [ForeignKey("Customer")]
        public int IdCustomer { get; set; }
        public String NameSchool { get; set; }
        public int graduation { get; set; }
        public int StartYear { get; set; }
        public int EndYear { get; set; }
        public int Class { get; set; }

        public Education() { }
        public Education(string nameSchool, int graduation, int startYear, int endYear, int Class)
        {
            NameSchool = nameSchool;
            this.graduation = graduation;
            StartYear = startYear;
            EndYear = endYear;
            this.Class = Class;
        }
    }
    
}
