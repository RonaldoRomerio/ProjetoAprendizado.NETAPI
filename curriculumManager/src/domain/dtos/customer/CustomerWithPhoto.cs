namespace curriculumManager.src.domain.dtos.customer
{
    public class CustomerWithPhoto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
        public DateTime BirthDate { get; set; }
        public string Adress { get; set; }
        public string Neighborhood { get; set; }
        public int CityId { get; set; }
        public int StateId { get; set; }
        public int AdressCode { get; set; }
        public string Email { get; set; }
        public string Resume { get; set; }
        public int PhoneNumber { get; set; }
        public int PhoneNumberOptional { get; set; }
    }
}
