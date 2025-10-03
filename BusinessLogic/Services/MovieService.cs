using AutoMapper;
using BusinessLogic.DTOs.MovieDto;
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

        public void Create(CreateMovieDto model)
        {
            var movie = mapper.Map<Movie>(model);

            db.Movies.Add(movie);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            if (id <= 0)
                throw new HttpException("Id can`t be negative ", HttpStatusCode.BadRequest);

            var movie = db.Movies.Find(id);

            if (movie == null)
                throw new HttpException($"Movie with id-{id} not found ", HttpStatusCode.NotFound);

            db.Movies.Remove(movie);
            db.SaveChanges();
        }

        public void Edit(EditMovieDto model)
        {
            var movie = mapper.Map<Movie>(model);

            db.Movies.Update(movie);
            db.SaveChanges();
        }

        public IList<MovieDto> GetAll(string? Title, string? Overview, double? Rating, bool? sortByBudgetAscending)
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

            var moviesDto = mapper.Map<IList<MovieDto>>(movies.ToList());

            return moviesDto;
        }

        public MovieDto? Get(int id)
        {
            if (id <= 0)
                throw new HttpException("Id can`t be negative ", HttpStatusCode.BadRequest);

            var movie = db.Movies.Find(id);

            if (movie == null)
                throw new HttpException($"Movie with id-{id} not found ", HttpStatusCode.NotFound);

            var movieDto = mapper.Map<MovieDto>(movie);

            return movieDto;
        }
    }
}
