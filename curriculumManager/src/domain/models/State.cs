using System.ComponentModel.DataAnnotations;

namespace curriculumManager.src.domain.models
{
    public class State
    {
        [Required]
        public string Name { get;}
        [Required]
        public string Acronym { get;}
    }
}
