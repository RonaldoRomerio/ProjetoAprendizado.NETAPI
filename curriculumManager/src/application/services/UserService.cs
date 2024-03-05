using curriculumManager.src.application.interfaces;
using curriculumManager.src.domain.models;
using curriculumManager.src.infrastructure.repositories;

namespace curriculumManager.src.application.services
{
    public class UserService : IUserLogin
    {
        protected IUserRepository _userRepository;

        public UserService(IUserRepository userRepository) { 
            _userRepository = userRepository;
        }
        public async Task<dynamic> login(string login, string senha)
        {
            User user = _userRepository.findUser(login);
            if (user == null)
                throw new UnauthorizedAccessException("Login ou senha inválido");

            var verifyPassword = BCrypt.Net.BCrypt.Verify(senha, user.Password);

            if (!verifyPassword)
                throw new UnauthorizedAccessException("Login ou senha inválido");

            return TokenService.GenerateToken(user);
        }

        public async Task<User> RegisterUser(User user)
        {

            if(await VerifyIfExists(user.Name))
            {
                throw new UnauthorizedAccessException("Usuário já existe");
            }
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password, 15);
            return await _userRepository.createUser(user);

        }

        public async Task<bool> VerifyIfExists(String name)
        {
            var exists = await _userRepository.verifyIfExists(name) > 0;
            return exists;
        }
    }
}
