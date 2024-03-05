using AutoMapper;
using curriculumManager.src.application.interfaces;
using curriculumManager.src.domain.dtos.user;
using curriculumManager.src.domain.models;
using curriculumManager.src.infrastructure.repositories;

namespace curriculumManager.src.application.services
{
    public class UserService : IUserLogin
    {
        protected readonly IUserRepository _userRepository;
        protected readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper) { 
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<LoggedUser> login(LoginUser loginUser)
        {
            User user = await _userRepository.findUser(loginUser.Name);
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
            completeUser.created_at = DateTime.UtcNow;

            var userCreated = await _userRepository.createUser(completeUser);

            return requestToken(userCreated);

        }

        public async Task<bool> VerifyIfExists(String name)
        {
            var exists = await _userRepository.verifyIfExists(name) > 0;
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
