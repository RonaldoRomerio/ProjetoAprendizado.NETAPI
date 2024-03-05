using AutoMapper;
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
        }
    }
}
