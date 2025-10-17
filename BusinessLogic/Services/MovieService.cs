using AutoMapper;
using BusinessLogic.DTOs.MovieDto;
using BusinessLogic.Interfaces;
using DataAccess.Data.Entities;
using DataAccess.Repositories;
using LinqKit;
using System.Net;

namespace BusinessLogic.Services
{
    public class MovieService : IMovieService
    {
        private readonly IRepository<Movie> repo;
        private readonly IMapper mapper;

        public MovieService(IRepository<Movie> repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }

        public async Task Create(CreateMovieDto model)
        {
            var movie = mapper.Map<Movie>(model);

            await repo.AddAsync(movie);
        }

        public async Task Delete(int id)
        {
            if (id <= 0)
                throw new HttpException("Id can`t be negative ", HttpStatusCode.BadRequest);

            var movie = await repo.GetByIdAsync(id);

            if (movie == null)
                throw new HttpException($"Movie with id-{id} not found ", HttpStatusCode.NotFound);

            await repo.DeleteAsync(movie);
        }

        public async Task Edit(EditMovieDto model)
        {
            var movie = mapper.Map<Movie>(model);

            await repo.UpdateAsync(movie);
        }

        public async Task<IList<MovieDto>> GetAll(string? Title, string? Overview, double? Rating, int pageNumber = 1)
        {
            var filterEx = PredicateBuilder.New<Movie>(true);

            if (Title != null)
            {
                filterEx.And(x => x.Title.Contains(Title.ToLower()));
            }

            if (Overview != null)
            {
                filterEx.And(x => x.Overview.Contains(Overview.ToLower()));
            }

            if (Rating != null)
            {
                filterEx.And(x => x.Rating == Rating);
            }

            var moviesDto = await repo.GetAllAsync(pageNumber, 5, filterEx);

            return mapper.Map<IList<MovieDto>>(moviesDto);
        }

        public async Task<MovieDto?> Get(int id)
        {
            if (id <= 0)
                throw new HttpException("Id can`t be negative ", HttpStatusCode.BadRequest);

            var movie = await repo.GetByIdAsync(id);

            if (movie == null)
                throw new HttpException($"Movie with id-{id} not found ", HttpStatusCode.NotFound);

            var movieDto = mapper.Map<MovieDto>(movie);

            return movieDto;
        }
    }
}
