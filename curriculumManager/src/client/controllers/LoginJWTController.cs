using curriculumManager.src.application.interfaces;
using curriculumManager.src.domain.dtos.user;
using curriculumManager.src.domain.models;
using Microsoft.AspNetCore.Mvc;

namespace curriculumManager.src.client.controllers
{
    public class LoginJWTController : BasicController<IUserLogin>
    {
        public LoginJWTController(IUserLogin service) : base(service){}

        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult> Authenticate([FromBody] LoginUser loginUser)
        {
            var userLogin = await _service.login(loginUser);
            return Ok(userLogin);
        }

        [HttpPost]
        [Route("RegisterAdmin")]
        public async Task<ActionResult> RegisterAdmin([FromBody] InsertUser user)
        {
            var newUser = await _service.RegisterUserAdmin(user);

            return Ok(newUser);

        }
    }
}

