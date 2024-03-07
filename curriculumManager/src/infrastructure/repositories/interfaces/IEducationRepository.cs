using curriculumManager.src.domain.models;

namespace curriculumManager.src.infrastructure.repositories.interfaces
{
    public interface IEducationRepository
    {
        public Task<Education> insertAsync(Education education);
        public Task<Education> UpdateAsync(Education education);
        public Task<int> DeleteAsync(int id);
        public Task<Education> getByIdAsync(int id);
        public Task<List<Education>> selectAll(int page);
    }
}
