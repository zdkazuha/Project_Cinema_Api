using BusinessLogic.DTOs.ActorDto;
using FluentValidation;

namespace BusinessLogic.Validators
{
    public class CreateActorDtoValidator : AbstractValidator<CreateActorDto>
    {
        public CreateActorDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Actor Name is required")
                .MinimumLength(3).WithMessage("Actor Name must be at least 3 characters long")
                .Matches("^[A-Z].*").WithMessage("{PropertyName} must start with uppercase letter.");
        }
    }
}
