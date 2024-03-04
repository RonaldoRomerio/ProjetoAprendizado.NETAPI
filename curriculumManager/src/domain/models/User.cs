using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace curriculumManager.src.domain.models
{
    [Table("User")]
    public class User
    {
        [Key]
        public int Id { get; private set; }
        public String Name { get; private set; }
        public String Password  { get; private set; }
        public String Roles { get; private set; }
        public Boolean Status { get; private set; }

        public User(int id, String name, String password, String roles)
        {
            this.Id = id;
            this.Name = name;
            this.Password = password;
            this.Roles = roles;
        }
    }
}
