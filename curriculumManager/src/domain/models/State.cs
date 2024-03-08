using System.ComponentModel.DataAnnotations;

namespace curriculumManager.src.domain.models
{
    public class State : EntityBase
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [StringLength(2)]
        public string Acronym { get; set; }
    }
}
