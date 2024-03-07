using AutoMapper;
using curriculumManager.src.domain.dtos.customer;
using curriculumManager.src.domain.dtos.education;
using curriculumManager.src.domain.dtos.experience;
using curriculumManager.src.domain.dtos.user;
using curriculumManager.src.domain.models;

namespace curriculumManager.src.application.mapping
{
    public class EntityToDTOMappingProfile : Profile
    {
        public EntityToDTOMappingProfile()
        {
            CreateMap<User, InsertUser>().ReverseMap();
            CreateMap<User, LoginUser>().ReverseMap();
            CreateMap<User, LoggedUser>().ReverseMap();

            CreateMap<Customer, CustomerWithPhoto>().ReverseMap();
            CreateMap<Customer, CustomerInsert>().ReverseMap();
            CreateMap<Customer, CustomerWithId>().ReverseMap();

            CreateMap<Experience, ExperienceInsert>().ReverseMap();
            CreateMap<Experience, ExperienceWithId>().ReverseMap();

            CreateMap<Education, EducationInsert>().ReverseMap();
            CreateMap<Education, EducationWithId>().ReverseMap();
        }
    }
}
