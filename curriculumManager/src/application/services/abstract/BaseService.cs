using AutoMapper;

namespace curriculumManager.src.application.services
{
    public abstract class BaseService<TInterface>
        where TInterface : class
    {
        protected readonly TInterface _repository;
        protected readonly IMapper _mapper;
        public BaseService(TInterface repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }
    }
}
