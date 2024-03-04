using curriculumManager.src.domain.models;

namespace curriculumManager.src.application.interfaces
{
    public interface IUserLogin
    {
        public Task<dynamic> login(string login, string senha);
        public Task<User> RegisterUser(User user);
        public Task<bool> VerifyIfExists(string name);

    }
}
