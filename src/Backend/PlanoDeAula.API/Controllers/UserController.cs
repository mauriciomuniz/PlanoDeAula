using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlanoDeAula.Communication.Requests;
using PlanoDeAula.Communication.Responses;

namespace PlanoDeAula.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisteredUserJson), StatusCodes.Status201Created)]
        public IActionResult Register(RequestRegisterUserJson request)
        {
            return Created();
        }
    }
}
