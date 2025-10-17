using AutoMapper;
using BusinessLogic.DTOs.ReviewDto;
using BusinessLogic.Interfaces;
using DataAccess.Data.Entities;
using DataAccess.Repositories;
using LinqKit;
using System.Net;

namespace BusinessLogic.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IRepository<Review> repo;
        private readonly IMapper mapper;

        public ReviewService(IRepository<Review> repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }

        public async Task Create(CreateReviewDto model)
        {
            var review = mapper.Map<Review>(model);

            await repo.AddAsync(review);
        }

        public async Task Delete(int id)
        {
            if (id < 0)
                throw new HttpException("Id can`t be negative ", HttpStatusCode.BadRequest);

            var review = await repo.GetByIdAsync(id);

            if (review == null)
                throw new HttpException($"Review with id-{id} not found ", HttpStatusCode.NotFound);

            await repo.DeleteAsync(review);
        }

        public async Task Edit(EditReviewDto model)
        {
            var review = mapper.Map<Review>(model);

            await repo.UpdateAsync(review);
        }

        public async Task<IList<ReviewDto>> GetAll(string? Comment, string? UserName, string? MovieTitle, int numberPage = 1)
        {
            var filterEx = PredicateBuilder.New<Review>(true);

            if (Comment != null)
                filterEx.And(x => x.Comment.Contains(Comment.ToLower()));

            if (UserName != null)
                filterEx.And(x => x.User!.UserName!.Contains(UserName.ToLower()));

            if (MovieTitle != null)
                filterEx.And(x => x.Movie.Title.Contains(MovieTitle.ToLower()));

            var reviews = await repo.GetAllAsync(numberPage, 5, filterEx, "User", "Movie");

            return mapper.Map<IList<ReviewDto>>(reviews);
        }

        public async Task<ReviewDto?> Get(int id)
        {
            if (id <= 0)
                throw new HttpException("Id can`t be negative ", HttpStatusCode.BadRequest);

            var review = await repo.GetByIdAsync(id, "Movie", "User");

            if (review == null) 
                throw new HttpException($"Review with id-{id} not found ", HttpStatusCode.NotFound);

            var reviewDto = mapper.Map<ReviewDto>(review);

            return reviewDto;
        }
    }
}
