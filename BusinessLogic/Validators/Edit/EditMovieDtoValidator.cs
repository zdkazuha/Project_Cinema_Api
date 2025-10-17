using FluentValidation;

namespace BusinessLogic.Validators.Create
{
    public class EditMovieDtoValidator : AbstractValidator<EditMovieDto>
    {
        public EditMovieDtoValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id is required")
                .NotNull().WithMessage("Id cannot be null");

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required")
                .MinimumLength(3).WithMessage("Title must be at least 3 characters long")
                .Matches("^[A-Z].*").WithMessage("{PropertyName} must start with uppercase letter.");

            RuleFor(x => x.Overview)
                .NotEmpty().WithMessage("Overview is required")
                .MinimumLength(10).WithMessage("Overview must be at least 10 characters long");

            RuleFor(x => x.Rating)
                .NotEmpty().WithMessage("Rating is required")
                .InclusiveBetween(1, 10).WithMessage("Rating must be between 1 and 10");

            RuleFor(x => x.Budget)
                .NotEmpty().WithMessage("Budget is required")
                .GreaterThan(0).WithMessage("Budget must be greater than 0");

            RuleFor(x => x.ReleaseDate)
                .NotEmpty().WithMessage("Release Date is required");

            RuleFor(x => x.PosterUrl)
                .NotEmpty().WithMessage("Poster Url is required");
        }
    }
}
