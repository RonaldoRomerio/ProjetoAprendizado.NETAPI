using curriculumManager.src.domain.models;
using curriculumManager.src.infrastructure.database.config;
using curriculumManager.src.infrastructure.repositories.interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace curriculumManager.src.infrastructure.repositories
{
    public class ExperienceRepository : BaseCrudRepository<Experience>, IExperienceRepository
    {
        public ExperienceRepository(AppDbContext context) : base(context){
            _dbSet = _context.Experience;
        }
        
    }
}
