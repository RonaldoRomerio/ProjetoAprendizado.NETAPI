using curriculumManager.src.domain.models;
using curriculumManager.src.infrastructure.database.config;
using curriculumManager.src.infrastructure.repositories.interfaces;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace curriculumManager.src.infrastructure.repositories
{
    public class EducationRepository : BaseCrudRepository<Education>, IEducationRepository
    {
        public EducationRepository(AppDbContext context) : base(context){
            _dbSet = _context.Education;
        }
        
    }
}
