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
            var movie = db.Movies.Find(id);

            return Ok(movie);
        }

        [HttpPost]
        public IActionResult Add(Movie movie)
        {
            db.Movies.Add(movie);
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

        [HttpPut]
        public IActionResult Edit(Movie movie)
        {
            db.Movies.Update(movie);
            db.SaveChanges();

            return Ok();
        }
    }
}
