using curriculumManager.src.domain.models;
using curriculumManager.src.infrastructure.database.config;
using Microsoft.EntityFrameworkCore;
using System.Reflection;


namespace curriculumManager.src.infrastructure.repositories
{
    public abstract class BaseCrudRepository<TEntity>
        where TEntity : class, new()
    {
        protected AppDbContext _context;
        protected DbSet<TEntity> _dbSet;

        public BaseCrudRepository(AppDbContext context)
        {
            _context = context;
        }
        public virtual async Task<int> DeleteAsync(int id)
        {
            TEntity objectToUpdate = await getByIdAsync(id);

            if (objectToUpdate == null)
                throw new KeyNotFoundException("id não encontrado");

            objectToUpdate.GetType().GetProperty("Deleted_at").SetValue(objectToUpdate, DateTime.UtcNow);

            await _context.SaveChangesAsync();

            return (int)objectToUpdate.GetType().GetProperty("Id").GetValue(objectToUpdate);
        }

        public virtual async Task<TEntity> getByIdAsync(int id)
        {

            var entityReturned = await _dbSet
                .Where(x =>
                    EF.Property<int?>(x, "Id") == id &&
                    EF.Property<DateTime?>(x, "Deleted_at") == null
                ).FirstOrDefaultAsync();

            return entityReturned;
        }

        public virtual async Task<TEntity> insertAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public virtual async Task<List<TEntity>> selectAll(int customerId)
        {

            PropertyInfo idProperty = typeof(TEntity).GetProperty("Id");
            PropertyInfo deletedAtProperty = typeof(TEntity).GetProperty("Deleted_at");

            return await _dbSet
                .Where(x => EF.Property<DateTime?>(x, "Deleted_at") == null)
                .AsNoTracking()
                .OrderBy(x => EF.Property<int>(x, "Id"))
                .ToListAsync();
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity objectToUpdate)
        {
            _dbSet.Update(objectToUpdate);
            await _context.SaveChangesAsync();

            return objectToUpdate;
        }
    }
}
