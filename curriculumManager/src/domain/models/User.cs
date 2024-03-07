using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using curriculumManager.src.domain.Enum;

namespace curriculumManager.src.domain.models
{
    [Table("User")]
    public class User : EntityBase
    {
        [Required]
        public String Name { get; set; }
        [Required]
        public String Password  { get; set; }
        [Required]
        public Roles Roles { get; set; }
        [Required]
        public Boolean Status { get; set; } = true;

        public User() { }
        public User(int id, String name, String password, Roles roles)
        {
            this.Id = id;
            this.Name = name;
            this.Password = password;
            this.Roles = roles;
        }
    }
}
