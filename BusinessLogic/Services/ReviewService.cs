using AutoMapper;
using BusinessLogic.DTOs.ReviewDto;
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

        public void Create(CreateReviewDto model)
        {
            var review = mapper.Map<Review>(model);

            db.Reviews.Add(review);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            if (id < 0)
                throw new HttpException("Id can`t be negative ", HttpStatusCode.BadRequest);

            var review = db.Reviews.Find(id);

            if (review == null)
                throw new HttpException($"Review with id-{id} not found ", HttpStatusCode.NotFound);

            db.Reviews.Remove(review);
            db.SaveChanges();
        }

        public void Edit(EditReviewDto model)
        {
            var review = mapper.Map<Review>(model);

            db.Reviews.Update(review);
            db.SaveChanges();
        }

        public IList<ReviewDto> GetAll()
        {
            var reviews = db.Reviews
                .Include(x => x.Movie)
                .Include(x => x.User)
                .ToList();

            var reviewsDto = mapper.Map<IList<ReviewDto>>(reviews);

            return reviewsDto;
        }

        public ReviewDto? Get(int id)
        {
            if (id <= 0)
                throw new HttpException("Id can`t be negative ", HttpStatusCode.BadRequest);

            var review = db.Reviews.Find(id);

            if (review == null) 
                throw new HttpException($"Review with id-{id} not found ", HttpStatusCode.NotFound);

            var reviewDto = mapper.Map<ReviewDto>(review);

            return reviewDto;
        }
    }
}
