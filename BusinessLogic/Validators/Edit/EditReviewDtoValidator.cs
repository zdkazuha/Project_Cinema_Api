using BusinessLogic.DTOs.ReviewDto;
using FluentValidation;

namespace BusinessLogic.Validators.Create
{
    public class EditReviewDtoValidator : AbstractValidator<EditReviewDto>
    {
        public EditReviewDtoValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id is required")
                .NotNull().WithMessage("Id cannot be null");

            RuleFor(x => x.Comment)
                .NotEmpty().WithMessage("Comment is required")
                .MinimumLength(10).WithMessage("Comment must be at least 10 characters long");

            RuleFor(x => x.MovieId)
                .NotEmpty().WithMessage("MovieId is required")
                .GreaterThan(0).WithMessage("MovieId must be greater than 0");

            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("UserId is required");
        }
    }
}
