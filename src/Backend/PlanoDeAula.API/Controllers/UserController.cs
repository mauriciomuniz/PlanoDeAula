using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlanoDeAula.Application.UseCases.User.Register;
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
            var useCase = new RegisterUserUseCase();
            var result  =  useCase.Execute(request);
            return Created(string.Empty,result);
        }
    }
}
