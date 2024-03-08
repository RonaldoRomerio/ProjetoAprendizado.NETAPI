using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace curriculumManager.src.domain.models
{
    public class City : EntityBase
    {
        [Required]
        public string Name { get; set; }
        [ForeignKey("State")]
        public int StateId { get; set; }
    }
}
