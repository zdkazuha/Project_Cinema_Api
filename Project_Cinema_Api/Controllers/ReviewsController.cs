using AutoMapper;
using BusinessLogic.DTOs.ReviewDto;
using BusinessLogic.Interfaces;
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
        private readonly IReviewService reviewService;

        public ReviewsController(IReviewService reviewService)
        {
            this.reviewService = reviewService;
        }

        [HttpGet("All")]
        public IActionResult GetReviews()
        {
            return Ok(reviewService.GetAll());
        }

        [HttpGet]
        public IActionResult GetreviewById(int id)
        {
            return Ok(reviewService.Get(id));
        }

        [HttpPost]
        public IActionResult Create(CreateReviewDto createReview)
        {
            reviewService.Create(createReview);

            return Ok();
        }

        [HttpPut]
        public IActionResult Edit(EditReviewDto editReview)
        {
           reviewService.Edit(editReview);

            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            reviewService.Delete(id);

            return Ok();
        }
    }
}
