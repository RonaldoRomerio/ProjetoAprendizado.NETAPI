using curriculumManager.src.domain.dtos.user;
using curriculumManager.src.domain.models;

namespace curriculumManager.src.application.interfaces
{
    public interface IUserLogin
    {
        public Task<LoggedUser> login(LoginUser loginUser);
        public Task<LoggedUser> RegisterUserAdmin(InsertUser user);
        public Task<bool> VerifyIfExists(string name);

    }
}
