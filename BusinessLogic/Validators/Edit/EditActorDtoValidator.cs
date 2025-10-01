using BusinessLogic.DTOs.ActorDto;
using FluentValidation;

namespace BusinessLogic.Validators.Edit
{
    public class EditActorDtoValidator : AbstractValidator<EditActorDto>
    {
        public EditActorDtoValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id is required")
                .NotNull().WithMessage("Id cannot be null");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Actor Name is required")
                .MinimumLength(3).WithMessage("Actor Name must be at least 3 characters long")
                .Matches("^[A-Z].*").WithMessage("{PropertyName} must start with uppercase letter.");
        }
    }
}
