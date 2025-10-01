using BusinessLogic.DTOs.UserDto;
using FluentValidation;

namespace BusinessLogic.Validators
{
    public class CreateUserDtoValidator : AbstractValidator<CreateUserDto>
    {
        public CreateUserDtoValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("UserName is required")
                .MinimumLength(3).WithMessage("UserName must be at least 3 characters long")
                .Matches("^[A-Z].*").WithMessage("{PropertyName} must start with uppercase letter.");
        }
    }
}
