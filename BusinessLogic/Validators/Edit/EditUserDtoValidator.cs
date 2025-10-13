using BusinessLogic.DTOs.ReviewDto;
using BusinessLogic.DTOs.UserDto;
using FluentValidation;

namespace BusinessLogic.Validators.Create
{
    public class EditUserDtoValidator : AbstractValidator<EditUserDto>
    {
        public EditUserDtoValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id is required");

            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("UserName is required")
                .MinimumLength(3).WithMessage("UserName must be at least 3 characters long")
                .Matches("^[A-Z].*").WithMessage("{PropertyName} must start with uppercase letter.");

            RuleFor(x => x.Country)
                .NotEmpty().WithMessage("Country is required")
                .MinimumLength(3).WithMessage("Country must be at least 3 characters long")
                .Matches("^[A-Z].*").WithMessage("{PropertyName} must start with uppercase letter.");
        }
    }
}
