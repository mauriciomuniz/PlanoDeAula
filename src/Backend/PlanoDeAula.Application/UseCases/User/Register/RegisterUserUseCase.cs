using PlanoDeAula.Application.Services.AutoMapper;
using PlanoDeAula.Application.Services.Cryptography;
using PlanoDeAula.Communication.Requests;
using PlanoDeAula.Communication.Responses;
using PlanoDeAula.Exceptions.ExceptionsBase;

namespace PlanoDeAula.Application.UseCases.User.Register
{
    public class RegisterUserUseCase
    {
        public ResponseRegisteredUserJson Execute(RequestRegisterUserJson request)
        {
            var cryptoPassword = new PasswordEncrypter();

            var autoMapper = new AutoMapper.MapperConfiguration( options =>
            {
                options.AddProfile(new AutoMapping());
            }).CreateMapper();

            Validate(request);
            var user = autoMapper.Map<Domain.Entities.User>(request);   

            user.Password = cryptoPassword.Encrypt(request.Password);


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
