using curriculumManager.src.application.interfaces;
using curriculumManager.src.application.services;
using curriculumManager.src.domain.models;
using Microsoft.AspNetCore.Mvc;

namespace curriculumManager.src.client.controllers
{
    [ApiController]
    [Route("v1")]
    public class LoginJWTController : ControllerBase
    {
        protected IUserLogin _UserService;

        public LoginJWTController(IUserLogin userService)
        {
            _UserService = userService;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult> Authenticate(String login, String senha)
        {
            var userLogin = await _UserService.login(login, senha);
            return Ok(userLogin);
        }

        [HttpPost]
        [Route("RegisterAdmin")]
        public async Task<ActionResult> RegisterAdmin([FromBody] User user)
        {
            var newUser = await _UserService.RegisterUser(user);

            if(newUser != null) {
                return Ok(newUser);
            } else
            {
                return BadRequest("usuário já existente");
            }
        }
    }
}
