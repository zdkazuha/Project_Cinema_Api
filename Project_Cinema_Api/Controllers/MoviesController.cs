using DataAccess.Data;
using DataAccess.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Project_Cinema_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly CinemaDbContext db;

        public MoviesController(CinemaDbContext db)
        {
            this.db = db;
        }

        [HttpGet("All")]
        public IActionResult GetMovies()
        {
            var movies = db.Movies.ToList();

            return Ok(movies);
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

            return Ok(movie);
        }

        [HttpGet]
        public IActionResult Created(Movie movie)
        {
            if(ModelState.IsValid)
            {
                return BadRequest("Invalid movie data");
            }

            db.Movies.Add(movie);
            db.SaveChanges();

            return CreatedAtAction(
                nameof(GetMovieById),
                new { id = movie.Id },
                movie
                );
        }

        [HttpPut]
        public IActionResult Edit(Movie movie)
        {
            db.Movies.Update(movie);
            db.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            db.Movies.Remove(db.Movies.Find(id));
            db.SaveChanges();

            return Ok();
        }
    }
}
