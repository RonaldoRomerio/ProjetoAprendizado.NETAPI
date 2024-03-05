using curriculumManager.src.domain.models;

namespace curriculumManager.src.infrastructure.repositories
{
    public interface IUserRepository
    {
        public Task<int> verifyIfExists(String name);
        public Task<User> createUser(User user);
        public Task<User> findUser(string login);
    }
}
