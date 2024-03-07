using AutoMapper;
using curriculumManager.src.application.interfaces;
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

        public async Task<CustomerWithPhoto> insertAsync(CustomerInsert customer)
        {
            var customerComplete = _mapper.Map<Customer>(customer);
            var CustomerDAO = await _customerRepository.insertAsync(customerComplete);
            var CustomerWithPhoto = _mapper.Map<CustomerWithPhoto>(CustomerDAO);
            return CustomerWithPhoto;
        }

        public async Task<List<CustomerWithPhoto>> selectAll(int page)
        {
            int PageSize = 10;
            int initialIndex = (page > 0 ? page - 1 : page) * PageSize;

            var CustomerDAO = await _customerRepository.selectAll(initialIndex);
            var CustomerWithPhoto = _mapper.Map<List<CustomerWithPhoto>>(CustomerDAO);
            return CustomerWithPhoto;
        }

        public async Task<CustomerWithPhoto> UpdateAsync(CustomerWithId customer)
        {
            var customerComplete = _mapper.Map<Customer>(customer);
            var CustomerDAO = await _customerRepository.UpdateAsync(customerComplete);
            var CustomerWithPhoto = _mapper.Map<CustomerWithPhoto>(CustomerDAO);
            return CustomerWithPhoto;
        }
        public async Task<bool> hasNextPage(int page)
        {
            int PageSize = 10;
            int initialIndex = (page > 0 ? page - 1 : page) * PageSize;

            return await _customerRepository.hasNextPage(initialIndex);
        }
    }
}
