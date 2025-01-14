using PlanoDeAula.Communication.Requests;
using PlanoDeAula.Communication.Responses;
using PlanoDeAula.Exceptions.ExceptionsBase;

namespace PlanoDeAula.Application.UseCases.User.Register
{
    public class RegisterUserUseCase
    {
        public ResponseRegisteredUserJson Execute(RequestRegisterUserJson request)
        {
            Validate(request);

            return new ResponseRegisteredUserJson
            { 
                Name = request.Name,
            };
        }

        private void Validate(RequestRegisterUserJson request) 
        {
            var validate = new RegisterUserValidator();
            var result = validate.Validate(request);

            if (result.IsValid == false)
            {
                var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errorMessages);
            }

        }
    }
}
