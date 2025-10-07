using BusinessLogic.DTOs.ReviewDto;
using BusinessLogic.Interfaces;
using DataAccess.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Project_Cinema_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewService reviewService;

        public ReviewsController(IReviewService reviewService)
        {
            this.reviewService = reviewService;
        }

        [HttpGet("All")]
        public async Task<ActionResult<IEnumerable<ReviewDto>>> GetReviews(string? Comment, string? UserName, string? MovieTitle, int numberPage = 1)
        {
            return Ok(await reviewService.GetAll(Comment, UserName, MovieTitle, numberPage));
        }

        [HttpGet]
        public async Task<ActionResult<ReviewDto>> GetreviewById(int id)
        {
            return Ok(await reviewService.Get(id));
        }

        [HttpPost]
        public async Task<ActionResult<Review>> Create(CreateReviewDto createReview)
        {
            await reviewService.Create(createReview);

            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult<ReviewDto>> Edit(EditReviewDto editReview)
        {
            await reviewService.Edit(editReview);

            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult<ReviewDto>> Delete(int id)
        {
            await reviewService.Delete(id);

            return NoContent();
        }
    }
}
