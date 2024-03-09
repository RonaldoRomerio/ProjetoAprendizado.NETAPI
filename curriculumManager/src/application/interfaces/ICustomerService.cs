using curriculumManager.src.domain.dtos.customer;

namespace curriculumManager.src.application.interfaces
{
    public interface ICustomerService
    {
        public Task<CustomerWithId> insertAsync(CustomerInsert customer);
        public Task<CustomerWithId> UpdateAsync(CustomerWithId customer);
        public Task<int> DeleteAsync(int id);
        public Task<CustomerWithPhoto> getByIdAsync(int id);
        public Task<List<CustomerWithId>> selectAll(int page);
        public Task<bool> hasNextPage(int page);
        public String savePhoto(CustomerPhoto Photo);
        public Task<bool> verifyIfExists(int id);
        public Task<CustomerWithPhoto> insertPhotoOnCustomer(int id, String photoPath);
    }
}
