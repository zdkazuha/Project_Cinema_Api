using AutoMapper;
using BusinessLogic.DTOs.ReviewDto;
using BusinessLogic.Helpers;
using BusinessLogic.Interfaces;
using DataAccess.Data;
using DataAccess.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace BusinessLogic.Services
{
    public class ReviewService : IReviewService
    {
        private readonly CinemaDbContext db;
        private readonly IMapper mapper;

        public ReviewService(CinemaDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task Create(CreateReviewDto model)
        {
            var review = mapper.Map<Review>(model);

            db.Reviews.Add(review);
            await db.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            if (id < 0)
                throw new HttpException("Id can`t be negative ", HttpStatusCode.BadRequest);

            var review = db.Reviews.Find(id);

            if (review == null)
                throw new HttpException($"Review with id-{id} not found ", HttpStatusCode.NotFound);

            db.Reviews.Remove(review);
            await db.SaveChangesAsync();
        }

        public async Task Edit(EditReviewDto model)
        {
            var review = mapper.Map<Review>(model);

            db.Reviews.Update(review);
            await db.SaveChangesAsync();
        }

        public async Task<IList<ReviewDto>> GetAll(string? Comment, string? UserName, string? MovieTitle, int numberPage = 1)
        {
            IQueryable<Review> reviews = db.Reviews
                .Include(x => x.Movie)
                .Include(x => x.User);

            if (Comment != null)
            {
                reviews = reviews
                    .Where(x => x.Comment.Contains(Comment.ToLower()));
            }

            if (UserName != null)
            {
                reviews = reviews
                    .Where(x => x.User.UserName.Contains(UserName.ToLower()));
            }

            if (MovieTitle != null)
            {
                reviews = reviews
                    .Where(x => x.Movie.Title.Contains(MovieTitle.ToLower()));
            }

            var reviewsPaged = await PagedList<Review>.CreateAsync(reviews, numberPage, 5);

            return mapper.Map<IList<ReviewDto>>(reviewsPaged);
        }

        public async Task<ReviewDto?> Get(int id)
        {
            if (id <= 0)
                throw new HttpException("Id can`t be negative ", HttpStatusCode.BadRequest);

            var review = await db.Reviews.FindAsync(id);

            if (review == null) 
                throw new HttpException($"Review with id-{id} not found ", HttpStatusCode.NotFound);

            var reviewDto = mapper.Map<ReviewDto>(review);

            return reviewDto;
        }
    }
}
