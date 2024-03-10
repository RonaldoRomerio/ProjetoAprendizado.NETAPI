using curriculumManager.src.domain.dtos.customer;
using curriculumManager.src.domain.models;

namespace curriculumManager.src.infrastructure.repositories.interfaces
{
    public interface ICustomerRepository : IbaseCrudInteface<Customer>
    {
        public Task<bool> hasNextPage(int page);
        public Task<int> verifyIfExists(int id);
        public Task<Customer> insertPhotoOnCustomer(int id, String photoPath);

    }
}
