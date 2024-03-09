using curriculumManager.src.domain.dtos.customer;
using curriculumManager.src.domain.models;

namespace curriculumManager.src.infrastructure.repositories.interfaces
{
    public interface ICustomerRepository
    {
        public Task<Customer> insertAsync(Customer customer);
        public Task<Customer> UpdateAsync(Customer customer);
        public Task<int> DeleteAsync(int id);
        public Task<Customer> getByIdAsync(int id);
        public Task<List<Customer>> selectAll(int page);
        public Task<bool> hasNextPage(int page);
        public Task<int> verifyIfExists(int id);
        public Task<Customer> insertPhotoOnCustomer(int id, String photoPath);

    }
}
