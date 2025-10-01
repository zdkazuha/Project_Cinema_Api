using AutoMapper;
using BusinessLogic.DTOs.MovieDto;
using BusinessLogic.Interfaces;
using DataAccess.Data;
using DataAccess.Data.Entities;

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
            if (id <= 0) return;

            var movie = db.Movies.Find(id);

            if (movie == null) return;

            db.Movies.Remove(movie);
            db.SaveChanges();
        }

        public void Edit(EditMovieDto model)
        {
            var movie = mapper.Map<Movie>(model);

            db.Movies.Update(movie);
            db.SaveChanges();
        }

        public IList<MovieDto> GetAll()
        {
            var movies = db.Movies.ToList();

            var moviesDto = mapper.Map<IList<MovieDto>>(movies);

            return moviesDto;
        }

        public MovieDto? Get(int id)
        {
            if (id <= 0) return null;

            var movie = db.Movies.Find(id);

            if (movie == null) return null;

            var movieDto = mapper.Map<MovieDto>(movie);

            return movieDto;
        }
    }
}
