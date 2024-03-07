using curriculumManager.src.domain.dtos.experience;
using curriculumManager.src.domain.models;

namespace curriculumManager.src.application.interfaces
{
    public interface IExperienceService
    {
        public Task<ExperienceWithId> insertAsync(ExperienceInsert experience);
        public Task<ExperienceWithId> UpdateAsync(ExperienceWithId experience);
        public Task<int> DeleteAsync(int id);
        public Task<ExperienceWithId> getByIdAsync(int id);
        public Task<List<ExperienceWithId>> selectAll(int idCostumer);
    }
}
