using System.ComponentModel.DataAnnotations;

namespace curriculumManager.src.domain.models
{
    public class State
    {
        [Required]
        public string Name { get;}
        [Required]
        [StringLength(2)]
        public string Acronym { get;}
    }
}
