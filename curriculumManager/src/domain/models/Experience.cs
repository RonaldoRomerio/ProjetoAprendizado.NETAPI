using System.ComponentModel.DataAnnotations.Schema;

namespace curriculumManager.src.domain.models
{
    public class Experience
    {
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public String Company { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public String Skills {  get; set; }

        public Experience() { }
        public Experience(int customerId, string company, DateTime startDate, DateTime endDate, string skills)
        {
            CustomerId = customerId;
            Company = company;
            StartDate = startDate;
            EndDate = endDate;
            Skills = skills;
        }
    }
}
