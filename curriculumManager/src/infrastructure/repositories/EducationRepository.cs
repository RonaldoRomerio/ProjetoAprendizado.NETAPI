using curriculumManager.src.domain.models;
using curriculumManager.src.infrastructure.database.config;
using curriculumManager.src.infrastructure.repositories.interfaces;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace curriculumManager.src.infrastructure.repositories
{
    public class EducationRepository : IEducationRepository
    {
        private readonly AppDbContext _context;
        public EducationRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<int> DeleteAsync(int id)
        {
            var EducationToUpdate = await getByIdAsync(id);

            if (EducationToUpdate == null)
                throw new KeyNotFoundException("id não encontrado");

            EducationToUpdate.Deleted_at = DateTime.UtcNow;
            await _context.SaveChangesAsync();

            return EducationToUpdate.Id;
        }

        public async Task<Education> getByIdAsync(int id)
        {
            return await _context
                .Education
                .FirstOrDefaultAsync(x => x.Id == id && x.Deleted_at == null);
        }

        public async Task<Education> insertAsync(Education education)
        {
            await _context.Education.AddAsync(education);
            await _context.SaveChangesAsync();

            return education;
        }

        public async Task<List<Education>> selectAll(int customerId)
        {
            return await _context
            .Education
            .Where(x => x.CustomerId == customerId && x.Deleted_at == null)
            .AsNoTracking()
            .ToListAsync();
        }

        public async Task<Education> UpdateAsync(Education education)
        {
            _context.Education.Update(education);
            await _context.SaveChangesAsync();

            return education;
        }
    }
}
