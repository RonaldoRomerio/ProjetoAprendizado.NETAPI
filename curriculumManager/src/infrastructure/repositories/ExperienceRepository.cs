using curriculumManager.src.domain.models;
using curriculumManager.src.infrastructure.database.config;
using curriculumManager.src.infrastructure.repositories.interfaces;
using Microsoft.EntityFrameworkCore;

namespace curriculumManager.src.infrastructure.repositories
{
    public class ExperienceRepository : IExperienceRepository
    {
        private readonly AppDbContext _context;
        public ExperienceRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<int> DeleteAsync(int id)
        {
            var ExperienceToUpdate = await getByIdAsync(id);

            if (ExperienceToUpdate == null)
                throw new KeyNotFoundException("id não encontrado");

            ExperienceToUpdate.Deleted_at = DateTime.UtcNow;
            await _context.SaveChangesAsync();

            return ExperienceToUpdate.Id;
        }

        public async Task<Experience> getByIdAsync(int id)
        {
            return await _context
                .Experience
                .FirstOrDefaultAsync(x => x.Id == id && x.Deleted_at == null);
        }

        public async Task<Experience> insertAsync(Experience experience)
        {
            await _context.Experience.AddAsync(experience);
            await _context.SaveChangesAsync();

            return experience;
        }

        public async Task<List<Experience>> selectAll(int customerId)
        {
            return await _context
                .Experience
                .Where(x => x.CustomerId == customerId && x.Deleted_at == null)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Experience> UpdateAsync(Experience experience)
        {
            _context.Experience.Update(experience);
            await _context.SaveChangesAsync();

            return experience;
        }
    }
}
