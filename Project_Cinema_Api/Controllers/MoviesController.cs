using AutoMapper;
using DataAccess.Data;
using DataAccess.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using BusinessLogic.DTOs.MovieDto;

namespace Project_Cinema_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly CinemaDbContext db;
        private readonly IMapper mapper;

        public MoviesController(CinemaDbContext db, IMapper mapper )
        {
            this.db = db;
            this.mapper = mapper;
        }

        [HttpGet("All")]
        public IActionResult GetMovies()
        {
            var movies = db.Movies.ToList();

            var moviesDto = mapper.Map<IEnumerable<MovieDto>>(movies);

            return Ok(moviesDto);
        }

        [HttpGet]
        public IActionResult GetMovieById(int id)
        {
            if(id <= 0)
            {
                return BadRequest("Invalid Id");
            }

            var movie = db.Movies.Find(id);

            if(movie == null)
            {
                return NotFound("Movie not found");
            }

            var movieDto = mapper.Map<MovieDto>(movie);

            return Ok(movieDto);
        }

        [HttpPost]
        public IActionResult Created(CreateMovieDto createMovie)
        {
            var movie = mapper.Map<Movie>(createMovie);

            db.Movies.Add(movie);
            db.SaveChanges();

            var movieDto = mapper.Map<MovieDto>(movie);

            return Ok();
        }

        [HttpPut]
        public IActionResult Edit(EditMovieDto editMovie)
        {
            var movie = mapper.Map<Movie>(editMovie); 

            db.Movies.Update(movie);
            db.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid Id");
            }

            var movie = db.Movies.Find(id);

            if(movie == null)
            {
                return NotFound("Movie not found");
            }

            db.Movies.Remove(movie);
            db.SaveChanges();

            return Ok();
        }
    }
}
