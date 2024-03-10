using AutoMapper;
using curriculumManager.src.application.interfaces;
using curriculumManager.src.domain.dtos.user;
using curriculumManager.src.domain.models;
using curriculumManager.src.infrastructure.repositories;

namespace curriculumManager.src.application.services
{
    public class UserService : BaseService<IUserRepository>, IUserLogin
    {
        public UserService(IUserRepository userRepository, IMapper mapper) : base(userRepository, mapper) { }
        public async Task<LoggedUser> login(LoginUser loginUser)
        {
            User user = await _repository.findUser(loginUser.Name);
            if (user == null)
                throw new UnauthorizedAccessException("Login ou senha inválido");

            var verifyPassword = BCrypt.Net.BCrypt.Verify(loginUser.Password, user.Password);

            if (!verifyPassword)
                throw new UnauthorizedAccessException("Login ou senha inválido");

            return requestToken(user);
        }

        public async Task<LoggedUser> RegisterUserAdmin(InsertUser user)
        {
            var completeUser = _mapper.Map<User>(user);

            completeUser.Roles = domain.Enum.Roles.admin;

            if(await VerifyIfExists(user.Name))
                throw new UnauthorizedAccessException("Usuário já existe");

            completeUser.Password = BCrypt.Net.BCrypt.HashPassword(completeUser.Password, 15);
            completeUser.Created_at = DateTime.UtcNow;

            var userCreated = await _repository.createUser(completeUser);

            return requestToken(userCreated);

        }

        public async Task<bool> VerifyIfExists(String name)
        {
            var exists = await _repository.verifyIfExists(name) > 0;
            return exists;
        }

        private LoggedUser requestToken(User user)
        {
            var loggeduser = _mapper.Map<LoggedUser>(user);
            var token = TokenService.GenerateToken(user);
            loggeduser.token = token;

            return loggeduser;
        }
    }
}
