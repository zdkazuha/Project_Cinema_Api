using AutoMapper;
using BusinessLogic.DTOs.ReviewDto;
using DataAccess.Data;
using DataAccess.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Project_Cinema_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly CinemaDbContext db;
        private readonly IMapper mapper;

        public ReviewsController(CinemaDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        [HttpGet("All")]
        public IActionResult GetReviews()
        {
            var reviews = db.Reviews
                .Include(x => x.Movie)
                .Include(x => x.User)
                .ToList();

            var reviewsDto = mapper.Map<IEnumerable<ReviewDto>>(reviews);

            return Ok(reviewsDto);
        }

        [HttpGet]
        public IActionResult GetreviewById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid Id");
            }

            var review = db.Reviews.Find(id);

            if (review == null)
            {
                return NotFound("review not found");
            }

            var reviewDto = mapper.Map<ReviewDto>(review);

            return Ok(reviewDto);
        }

        [HttpPost]
        public IActionResult Create(CreateReviewDto createReview)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var review = mapper.Map<Review>(createReview);

            db.Reviews.Add(review);
            db.SaveChanges();

            return Ok();
        }

        [HttpPut]
        public IActionResult Update(EditReviewDto editReview)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var review = mapper.Map<Review>(editReview);

            db.Reviews.Update(review);
            db.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (id < 0)
            {
                return BadRequest("Invalid Id");
            }

            var review = db.Reviews.Find(id);

            if (review == null)
            {
                return NotFound("review not found");
            }

            db.Reviews.Remove(review);
            db.SaveChanges();

            return Ok();
        }
    }
}
