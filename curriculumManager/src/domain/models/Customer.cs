using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace curriculumManager.src.domain.models
{
    public class Customer : EntityBase
    {
        [Required]
        public string Name { get; set; }
        public string Photo { get; set; }
        public DateTime BirthDate { get; set; }
        public string Adress { get; set; }
        public string Neighborhood { get; set; }
        [ForeignKey("City")]
        public int CityId { get; set; }
        [ForeignKey("State")]
        public int StateId { get; set; }
        public int AdressCode { get; set; }
        [Required]
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "Por favor, insira um endereço de e-mail válido.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string Resume { get; set; }
        [Required]
        public int PhoneNumber { get; set; }
        public int PhoneNumberOptional { get; set; }

        public Customer() { }

        public Customer(string name, DateTime birthDate, string adress, 
            string neighborhood, int stateId, int cityId, int adressCode, 
            string email, string resume, int phoneNumber, int phoneNumberOptional)
        {
            Name = name;
            BirthDate = birthDate;
            Adress = adress;
            Neighborhood = neighborhood;
            StateId = stateId;
            CityId = cityId;
            AdressCode = adressCode;
            Email = email;
            Resume = resume;
            PhoneNumber = phoneNumber;
            PhoneNumberOptional = phoneNumberOptional;
        }
    }
}
