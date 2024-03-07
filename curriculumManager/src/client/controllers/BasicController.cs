using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace curriculumManager.src.client.controllers
{
    [Route("v1/")]
    [ApiController]
    public class BasicController<TInteface> : ControllerBase
         where TInteface : class
    {
        protected readonly TInteface _service;

        public BasicController(TInteface service)
        {
            _service = service;
        }
    }
}
