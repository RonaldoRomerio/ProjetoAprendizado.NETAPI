using curriculumManager.src.application.interfaces;
using curriculumManager.src.domain.models;

namespace curriculumManager.src.infrastructure.repositories.interfaces
{
    public interface IbaseCrudInteface<TEntity> 
        where  TEntity : class
    {
        public Task<TEntity> insertAsync(TEntity customer);
        public Task<TEntity> UpdateAsync(TEntity customer);
        public Task<TEntity> getByIdAsync(int id);
        public Task<List<TEntity>> selectAll(int page, List<IFilter> filters);
        public Task<int> DeleteAsync(int id);
    }
}
