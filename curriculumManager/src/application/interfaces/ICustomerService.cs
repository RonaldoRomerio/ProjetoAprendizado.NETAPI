using curriculumManager.src.domain.dtos.customer;

namespace curriculumManager.src.application.interfaces
{
    public interface ICustomerService
    {
        public Task<CustomerWithPhoto> insertAsync(CustomerInsert customer);
        public Task<CustomerWithPhoto> UpdateAsync(CustomerWithId customer);
        public Task<int> DeleteAsync(int id);
        public Task<CustomerWithPhoto> getByIdAsync(int id);

        public Task<List<CustomerWithPhoto>> selectAll(int page);
        public Task<bool> hasNextPage(int page);
    }
}
