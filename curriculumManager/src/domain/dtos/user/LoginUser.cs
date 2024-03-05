using System.ComponentModel.DataAnnotations;

namespace curriculumManager.src.domain.dtos.user
{
    public class LoginUser
    {
        [Required]
        public String Name { get; set; }
        [Required]
        public String Password { get; set; }
    }
}
