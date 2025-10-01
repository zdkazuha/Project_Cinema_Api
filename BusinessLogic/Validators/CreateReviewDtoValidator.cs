using BusinessLogic.DTOs.ReviewDto;
using FluentValidation;

namespace BusinessLogic.Validators
{
    public class CreateReviewDtoValidator : AbstractValidator<CreateReviewDto>
    {
        public CreateReviewDtoValidator()
        {
            RuleFor(x => x.Comment)
                .NotEmpty().WithMessage("Comment is required")
                .MinimumLength(10).WithMessage("Comment must be at least 10 characters long");

            RuleFor(x => x.MovieId)
                .NotEmpty().WithMessage("MovieId is required")
                .GreaterThan(0).WithMessage("MovieId must be greater than 0");

            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("UserId is required")
                .GreaterThan(0).WithMessage("UserId must be greater than 0");
        }
    }
}
