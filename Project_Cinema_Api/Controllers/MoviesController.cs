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

            return Ok(movie);
        }

        [HttpPost]
        public IActionResult Created(Movie movie)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Movies.Add(movie);
            db.SaveChanges();

            return CreatedAtAction(
                nameof(GetMovieById),
                new { id = movie.Id },
                movie);
        }

        [HttpPut]
        public IActionResult Edit(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

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

            db.Movies.Remove(db.Movies.Find(id));
            db.SaveChanges();

            return Ok();
        }
    }
}
