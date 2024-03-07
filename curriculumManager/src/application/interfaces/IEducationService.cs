using curriculumManager.src.domain.dtos.education;
using curriculumManager.src.domain.models;

namespace curriculumManager.src.application.interfaces
{
    public interface IEducationService
    {
        public Task<EducationWithId> insertAsync(EducationInsert education);
        public Task<EducationWithId> UpdateAsync(EducationWithId education);
        public Task<int> DeleteAsync(int id);
        public Task<EducationWithId> getByIdAsync(int id);
        public Task<List<EducationWithId>> selectAll(int customerId);
    }
}
