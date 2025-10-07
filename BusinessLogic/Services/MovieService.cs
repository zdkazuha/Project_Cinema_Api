using AutoMapper;
using BusinessLogic.DTOs.MovieDto;
using BusinessLogic.Helpers;
using BusinessLogic.Interfaces;
using DataAccess.Data;
using DataAccess.Data.Entities;
using System.Net;

namespace BusinessLogic.Services
{
    public class MovieService : IMovieService
    {
        private readonly CinemaDbContext db;
        private readonly IMapper mapper;

        public MovieService(CinemaDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task Create(CreateMovieDto model)
        {
            var movie = mapper.Map<Movie>(model);

            db.Movies.Add(movie);
            await db.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            if (id <= 0)
                throw new HttpException("Id can`t be negative ", HttpStatusCode.BadRequest);

            var movie = db.Movies.Find(id);

            if (movie == null)
                throw new HttpException($"Movie with id-{id} not found ", HttpStatusCode.NotFound);

            db.Movies.Remove(movie);
            await db.SaveChangesAsync();
        }

        public async Task Edit(EditMovieDto model)
        {
            var movie = mapper.Map<Movie>(model);

            db.Movies.Update(movie);
            await db.SaveChangesAsync();
        }

        public async Task<IList<MovieDto>> GetAll(string? Title, string? Overview, double? Rating, bool? sortByBudgetAscending, int pageNumber = 1)
        {
            IQueryable<Movie> movies = db.Movies;

            if (Title != null)
            {
                movies = movies
                    .Where(x => x.Title.Contains(Title.ToLower()));
            }

            if (Overview != null)
            {
                movies = movies
                    .Where(x => x.Overview.Contains(Overview.ToLower()));
            }

            if (Rating != null)
            {
                movies = movies
                    .Where(x => x.Rating == Rating);
            }

            if (sortByBudgetAscending != null)
            {
                movies = sortByBudgetAscending == true
                    ? movies.OrderBy(x => x.Budget)
                    : movies.OrderByDescending(x => x.Budget);
            }


            var moviesDto = await PagedList<Movie>.CreateAsync(db.Movies, pageNumber, 5);

            return mapper.Map<IList<MovieDto>>(moviesDto);
        }

        public async Task<MovieDto?> Get(int id)
        {
            if (id <= 0)
                throw new HttpException("Id can`t be negative ", HttpStatusCode.BadRequest);

            var movie = await db.Movies.FindAsync(id);

            if (movie == null)
                throw new HttpException($"Movie with id-{id} not found ", HttpStatusCode.NotFound);

            var movieDto = mapper.Map<MovieDto>(movie);

            return movieDto;
        }
    }
}
