using BusinessLogic.DTOs.MovieActorDto;
using FluentValidation;

namespace BusinessLogic.Validators
{
    public class CreateMovieActorDtoValidator : AbstractValidator<CreateMovieActorDto>
    {
        public CreateMovieActorDtoValidator()
        {
            RuleFor(x => x.CharacterName)
                .NotEmpty().WithMessage("CharacterName is required")
                .MinimumLength(3).WithMessage("CharacterName must be at least 3 characters long")
                .Matches("^[A-Z].*").WithMessage("{PropertyName} must start with uppercase letter.");

            RuleFor(x => x.MovieId)
                .NotEmpty().WithMessage("MovieId is required")
                .GreaterThan(0).WithMessage("MovieId must be greater than 0");

            RuleFor(x => x.ActorId)
                .NotEmpty().WithMessage("ActorId is required")
                .GreaterThan(0).WithMessage("ActorId must be greater than 0");
        }
    }
}
