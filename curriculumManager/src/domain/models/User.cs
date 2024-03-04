using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace curriculumManager.src.domain.models
{
    [Table("User")]
    public class User
    {
        [Key]
        public int Id { get; private set; }
        public String name { get; private set; }
        public String senha  { get; private set; }
        public String Roles { get; private set; }
        public Boolean Status { get; private set; }

        public User(int Id, String name, String senha, String Roles)
        {
            this.Id = Id;
            this.name = name;
            this.senha = senha;
            this.Roles = Roles;
        }
    }
}
