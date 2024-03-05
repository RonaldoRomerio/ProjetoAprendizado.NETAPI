using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text;

namespace curriculumManager.src.domain.models
{
    public class EntityBase
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime created_at { get; set; }

        public override string ToString()
        {
            int count = 0;
            Type tipoClasse = this.GetType();
            StringBuilder toString = new StringBuilder();

            PropertyInfo[] propriedades = tipoClasse.GetProperties();

            foreach (PropertyInfo propriedade in propriedades)
            {
                if (count > 0) toString.Append(" , ");
                toString.Append(propriedade.Name + " = " + propriedade.GetValue(this));
                count++;
            }

            return toString.ToString();
        }
    }
}
