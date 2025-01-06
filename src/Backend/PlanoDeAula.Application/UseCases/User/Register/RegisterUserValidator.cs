using FluentValidation;
using PlanoDeAula.Communication.Requests;
using PlanoDeAula.Exceptions;

namespace PlanoDeAula.Application.UseCases.User.Register
{
    public class RegisterUserValidator : AbstractValidator<RequestRegisterUserJson>
    {
        public RegisterUserValidator()
        {
            RuleFor(user => user.Name).NotEmpty().WithMessage(ResourceMessagesException.NAME_EMPTY);
            RuleFor(user => user.Email).NotEmpty().WithMessage("O email não pode ser vazio");
            RuleFor(user => user.Email).EmailAddress().WithMessage("Precisa ser um email");
            RuleFor(user => user.Password.Length).GreaterThanOrEqualTo(6).WithMessage("Precisa ter 6 ou mais caracteres");
        }
    }
}
