using curriculumManager.src.domain.models;
using curriculumManager.src.infrastructure.database.config;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace curriculumManager.src.infrastructure.repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User> createUser(User user)
        {
            await _context.User.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<int> verifyIfExists(string name)
        {
            return await _context.User.CountAsync(u => u.Name == name);
        }

        public async Task<User> findUser(string login)
        {
            return await _context.User.FirstOrDefaultAsync(u => u.Name == login);
        }
    }
}
