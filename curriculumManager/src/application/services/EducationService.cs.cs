using AutoMapper;
using curriculumManager.src.application.interfaces;
using curriculumManager.src.domain.dtos.education;
using curriculumManager.src.domain.dtos.experience;
using curriculumManager.src.domain.Enum;
using curriculumManager.src.domain.models;
using curriculumManager.src.infrastructure.repositories.interfaces;

namespace curriculumManager.src.application.services
{
    public class EducationService : BaseService<IEducationRepository>, IEducationService
    {
        public EducationService(IEducationRepository educationRepository, IMapper mapper) : base(educationRepository, mapper) { }

        public async Task<int> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<EducationWithId> getByIdAsync(int id)
        {
            var educationDAO = await _repository.getByIdAsync(id);
            var educationWithId = _mapper.Map<EducationWithId>(educationDAO);

            return educationWithId;
        }

        public async Task<EducationWithId> insertAsync(EducationInsert education)
        {
            var educationComplete = _mapper.Map<Education>(education);
            educationComplete.Created_at = DateTime.UtcNow;
            var educationDAO = await _repository.insertAsync(educationComplete);
            var educationWithId = _mapper.Map<EducationWithId>(educationDAO);

            return educationWithId;
        }

        public async Task<List<EducationWithId>> selectAll(int customerId)
        {
            List<IFilter> filters = new List<IFilter>();

            filters.Add(new Filter<int>("Id", FilterOperator.Equal, 2));
            filters.Add(new Filter<int>("CustomerId", FilterOperator.Equal, customerId));
            filters.Add(new Filter<DateTime?>("Deleted_At", FilterOperator.Equal, null));

            var educationDAO = await _repository.selectAll(customerId, filters);
            var educationWithId = _mapper.Map<List<EducationWithId>>(educationDAO);

            return educationWithId;
        }

        public async Task<EducationWithId> UpdateAsync(EducationWithId education)
        {
            var educationComplete = _mapper.Map<Education>(education);
            var educationDAO = await _repository.UpdateAsync(educationComplete);
            var educationWithId = _mapper.Map<EducationWithId>(educationDAO);

            return educationWithId;
        }
    }
}
