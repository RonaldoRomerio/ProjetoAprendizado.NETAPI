using curriculumManager.src.application.interfaces;
using curriculumManager.src.domain.dtos.user;
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
        public async Task<ActionResult> Authenticate([FromBody] LoginUser loginUser)
        {
            var userLogin = await _UserService.login(loginUser);
            return Ok(userLogin);
        }

        [HttpPost]
        [Route("RegisterAdmin")]
        public async Task<ActionResult> RegisterAdmin([FromBody] InsertUser user)
        {
            var newUser = await _UserService.RegisterUserAdmin(user);

            return Ok(newUser);

        }
    }
}

