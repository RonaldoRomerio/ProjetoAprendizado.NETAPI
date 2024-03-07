using curriculumManager.src.domain.models;

namespace curriculumManager.src.infrastructure.repositories.interfaces
{
    public interface IExperienceRepository
    {
        public Task<Experience> insertAsync(Experience experience);
        public Task<Experience> UpdateAsync(Experience experience);
        public Task<int> DeleteAsync(int id);
        public Task<Experience>  getByIdAsync(int id);
        public Task<List<Experience>> selectAll(int idCostumer);
    }
}
