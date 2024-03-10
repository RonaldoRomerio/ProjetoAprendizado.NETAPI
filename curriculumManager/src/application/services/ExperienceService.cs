using AutoMapper;
using curriculumManager.src.application.interfaces;
using curriculumManager.src.domain.dtos.experience;
using curriculumManager.src.domain.models;
using curriculumManager.src.infrastructure.database.config;
using curriculumManager.src.infrastructure.repositories.interfaces;

namespace curriculumManager.src.application.services
{
    public class ExperienceService : BaseService<IExperienceRepository>, IExperienceService
    {

        public ExperienceService(IExperienceRepository experienceRepository, IMapper mapper) : base(experienceRepository, mapper) {}

        public async Task<int> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<ExperienceWithId> getByIdAsync(int id)
        {
            var experienceDAO = await _repository.getByIdAsync(id);
            var experienceWithId = _mapper.Map<ExperienceWithId>(experienceDAO);

            return experienceWithId;

        }

        public async Task<ExperienceWithId> insertAsync(ExperienceInsert experience)
        {
            var experienceComplete = _mapper.Map<Experience>(experience);
            experienceComplete.Created_at = DateTime.UtcNow;
            var experienceDAO = await _repository.insertAsync(experienceComplete);
            var experienceWithId = _mapper.Map<ExperienceWithId>(experienceDAO);

            return experienceWithId;
        }

        public async Task<List<ExperienceWithId>> selectAll(int customerId)
        {
            var experienceDAO = await _repository.selectAll(customerId);
            var experienceWithId = _mapper.Map<List<ExperienceWithId>>(experienceDAO);

            return experienceWithId;
        }

        public async Task<ExperienceWithId> UpdateAsync(ExperienceWithId experience)
        {
            var experienceComplete = _mapper.Map<Experience>(experience);
            var experienceDAO = await _repository.UpdateAsync(experienceComplete);
            var experienceWithId = _mapper.Map<ExperienceWithId>(experienceDAO);

            return experienceWithId;
        }
    }
}
