using curriculumManager.src.domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace curriculumManager.src.domain.dtos.user
{
    public class LoggedUser
    {
        [Required]
        public String Name { get; set; }
        [Required]
        public Roles Role { get; set; }
        [Required]
        public String token { get; set; }
    }
}
