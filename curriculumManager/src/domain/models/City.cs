using System.ComponentModel.DataAnnotations;

namespace curriculumManager.src.domain.models
{
    public class City : EntityBase
    {
        [Required]
        public string Name { get; }
    }
}
