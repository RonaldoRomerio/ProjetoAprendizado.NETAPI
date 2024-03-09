using curriculumManager.src.domain.dtos.customer;
using curriculumManager.src.domain.models;
using curriculumManager.src.infrastructure.database.config;
using curriculumManager.src.infrastructure.repositories.interfaces;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace curriculumManager.src.infrastructure.repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _context;

        public CustomerRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<int> DeleteAsync(int id)
        {
            var CustomerToUpdate = await getByIdAsync(id);

            if (CustomerToUpdate == null)
                throw new KeyNotFoundException("id não encontrado");

            CustomerToUpdate.Deleted_at = DateTime.UtcNow;
            await _context.SaveChangesAsync();

            return CustomerToUpdate.Id;
        }

        public async Task<List<Customer>> selectAll(int page)
        {
            return await _context
             .Customer
             .AsNoTracking()
             .Skip(page)
             .Take(10)
             .Where(x => x.Deleted_at == null)
             .ToListAsync();
        }

        public async Task<Customer> getByIdAsync(int id)
        {
            var customer = await _context
            .Customer
            .Where(x => x.Id == id && x.Deleted_at == null)
            .FirstOrDefaultAsync();

            return customer;
        }

        public async Task<Customer> insertAsync(Customer customer)
        {
            await _context.Customer.AddAsync(customer);
            await _context.SaveChangesAsync();

            return customer;
        }

        public async Task<Customer> UpdateAsync(Customer customer)
        {
            _context.Customer.Update(customer);
            await _context.SaveChangesAsync();

            return customer;
        }
        public async Task<bool> hasNextPage(int page)
        {
            bool hasNextPage = await _context.Customer.Skip(page + 10).AnyAsync();
            return hasNextPage;
        }
        public async Task<int> verifyIfExists(int id)
        {
            return await _context.Customer.CountAsync(x => x.Id == id && x.Deleted_at == null);
        }
        public async Task<Customer> insertPhotoOnCustomer(int id, String photoPath)
        {
            var CustomerToUpdate = await getByIdAsync(id);

            CustomerToUpdate.Photo = photoPath;
            await _context.SaveChangesAsync();

            return CustomerToUpdate;
        }
    }
}
