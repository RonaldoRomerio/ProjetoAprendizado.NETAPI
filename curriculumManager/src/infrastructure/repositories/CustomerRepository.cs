using curriculumManager.src.domain.models;
using curriculumManager.src.infrastructure.database.config;
using curriculumManager.src.infrastructure.repositories.interfaces;
using Microsoft.EntityFrameworkCore;


namespace curriculumManager.src.infrastructure.repositories
{
    public class CustomerRepository : BaseCrudRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(AppDbContext context) : base(context)
        {
            _dbSet = _context.Customer;
        }
        public override async Task<List<Customer>> selectAll(int page)
        {
            return await _context
             .Customer
             .AsNoTracking()
             .Where(x => x.Deleted_at == null)
             .OrderBy(x => x.Name)
             .Skip(page)
             .Take(10)
             .ToListAsync();
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
