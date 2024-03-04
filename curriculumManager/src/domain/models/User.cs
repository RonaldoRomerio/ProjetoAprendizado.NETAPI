using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace curriculumManager.src.domain.models
{
    [Table("User")]
    public class User
    {
        [Key]
        public int Id { get; set; }
        public String Name { get; set; }
        public String Password  { get; set; }
        public String Roles { get; set; }
        public Boolean Status { get; set; }

        public User(int id, String name, String password, String roles)
        {
            this.Id = id;
            this.Name = name;
            this.Password = password;
            this.Roles = roles;
        }
    }
}
