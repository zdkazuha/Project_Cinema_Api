using BusinessLogic.DTOs.GenreDto;
using FluentValidation;

namespace BusinessLogic.Validators
{
    public class EditGenreDtoValidator : AbstractValidator<EditGenreDto>
    {
        public EditGenreDtoValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id is required")
                .NotNull().WithMessage("Id cannot be null");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Genre Name is required")
                .MinimumLength(3).WithMessage("Genre Name must be at least 3 characters long")
                .Matches("^[A-Z].*").WithMessage("{PropertyName} must start with uppercase letter.");
        }
    }
}
