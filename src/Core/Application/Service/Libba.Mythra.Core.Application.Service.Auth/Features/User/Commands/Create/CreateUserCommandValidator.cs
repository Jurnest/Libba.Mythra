using FluentValidation;
using Libba.Mythra.Core.Application.Contract.Services.Auth.User.Commands;

namespace Libba.Mythra.Core.Application.Service.Auth.Features.User.Commands.Create;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty().MaximumLength(50);
        RuleFor(c => c.Surname).NotEmpty().MaximumLength(50);
        RuleFor(c => c.Email).NotEmpty().MaximumLength(100).EmailAddress();
        RuleFor(c => c.Password).NotEmpty().MinimumLength(6).WithMessage("Password must be at least 6 characters long.");
    }
}
