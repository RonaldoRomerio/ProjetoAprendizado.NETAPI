using curriculumManager.src.domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace curriculumManager.src.domain.dtos.user
{
    public class InsertUser
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
