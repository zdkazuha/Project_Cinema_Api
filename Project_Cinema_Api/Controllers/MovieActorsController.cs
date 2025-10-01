using AutoMapper;
using BusinessLogic.DTOs.MovieActorDto;
using DataAccess.Data;
using DataAccess.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Project_Cinema_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieActorsController : ControllerBase
    {
        private readonly CinemaDbContext db;
        private readonly IMapper mapper;

        public MovieActorsController(CinemaDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }
        [HttpGet("All")]
        public IActionResult GetMovieActors()
        {
            var movieActors = db.MovieActors
                .Include(x => x.Movie)
                .Include(x => x.Actor)
                .ToList();

            var movieActorsDto = mapper.Map<IEnumerable<MovieActorDto>>(movieActors);

            return Ok(movieActorsDto);
        }

        [HttpGet]
        public IActionResult GetMovieActorById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid Id");
            }

            var movieActor = db.MovieActors.Find(id);

            if (movieActor == null)
            {
                return NotFound("Movie Actor not found");
            }

            var movieActorDto = mapper.Map<MovieActorDto>(movieActor);

            return Ok(movieActorDto);
        }

        [HttpPost]
        public IActionResult Create(CreateMovieActorDto createMovieActor)
        {
            var movieActor = mapper.Map<MovieActor>(createMovieActor);

            db.MovieActors.Add(movieActor);
            db.SaveChanges();

            return Ok();
        }

        [HttpPut]
        public IActionResult Update(EditMovieActorDto editMovieActor)
        {
            var movieActor = mapper.Map<MovieActor>(editMovieActor);

            db.MovieActors.Update(movieActor);
            db.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (id < 0)
            {
                return BadRequest("Invalid Id");
            }

            var movieActor = db.MovieActors.Find(id);

            if (movieActor == null)
            {
                return NotFound("Movie Actor not found");
            }

            db.MovieActors.Remove(movieActor);
            db.SaveChanges();

            return Ok();
        }
    }
}
