using AutoMapper;
using curriculumManager.src.application.interfaces;
using curriculumManager.src.application.util;
using curriculumManager.src.domain.dtos.customer;
using curriculumManager.src.domain.models;
using curriculumManager.src.infrastructure.repositories.interfaces;

namespace curriculumManager.src.application.services
{
    public class CustomerService : ICustomerService
    {

        private readonly ICustomerRepository _customerRepository;
        protected readonly IMapper _mapper;

        public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }
        public async Task<int> DeleteAsync(int id)
        {
            return await _customerRepository.DeleteAsync(id);
        }

        public async Task<CustomerWithPhoto> getByIdAsync(int id)
        {
            var CustomerDAO = await _customerRepository.getByIdAsync(id);
            var CustomerWithPhoto = _mapper.Map<CustomerWithPhoto>(CustomerDAO);
            return CustomerWithPhoto;
        }

        public async Task<CustomerWithId> insertAsync(CustomerInsert customer)
        {
            var customerComplete = _mapper.Map<Customer>(customer);
            customerComplete.Created_at = DateTime.UtcNow;
            var CustomerDAO = await _customerRepository.insertAsync(customerComplete);
            var CustomerMapped = _mapper.Map<CustomerWithId>(CustomerDAO);
            return CustomerMapped;
        }

        public async Task<List<CustomerWithId>> selectAll(int page)
        {
            int PageSize = 10;
            int initialIndex = (page > 0 ? page - 1 : page) * PageSize;

            var CustomerDAO = await _customerRepository.selectAll(initialIndex);
            var CustomerMapped = _mapper.Map<List<CustomerWithId>>(CustomerDAO);
            return CustomerMapped;
        }

        public async Task<CustomerWithId> UpdateAsync(CustomerWithId customer)
        {
            var customerComplete = _mapper.Map<Customer>(customer);
            var CustomerDAO = await _customerRepository.UpdateAsync(customerComplete);
            var CustomerMapped = _mapper.Map<CustomerWithId>(CustomerDAO);
            return CustomerMapped;
        }
        public async Task<bool> hasNextPage(int page)
        {
            int PageSize = 10;
            int initialIndex = (page > 0 ? page - 1 : page) * PageSize;

            return await _customerRepository.hasNextPage(initialIndex);
        }

        public string savePhoto(CustomerPhoto customer)
        {
            var typeArchive = ValidTypeArchive.validImageType(customer.Photo.ContentType);

            //String ImageName = DateTime.UtcNow.ToString().Replace("/", "").Replace(" ", "").Replace(":", "");

            var filePath = Path.Combine("src", "storage", "Photos", customer.Id + "." + typeArchive);
            using Stream fileStream = new FileStream(filePath, FileMode.Create);
            customer.Photo.CopyTo(fileStream);

            return filePath;
        }

        public async Task<bool> verifyIfExists(int id)
        {
            return await _customerRepository.verifyIfExists(id) > 0;
        }

        public async Task<CustomerWithPhoto> insertPhotoOnCustomer(int id, String photoPath)
        {
            var customerDAO = await _customerRepository.insertPhotoOnCustomer(id, photoPath);
            var CustomerMapped = _mapper.Map<CustomerWithPhoto>(customerDAO);
            return CustomerMapped;
        }
    }
}
