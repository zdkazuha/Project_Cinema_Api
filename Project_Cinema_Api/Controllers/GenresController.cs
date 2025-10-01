using AutoMapper;
using BusinessLogic.DTOs.GenreDto;
using DataAccess.Data;
using DataAccess.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Project_Cinema_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly CinemaDbContext db;
        private readonly IMapper mapper;

        public GenresController(CinemaDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        [HttpGet("All")]
        public IActionResult GetGenres()
        {
            var genres = db.Genres.ToList();

            var genresDto = mapper.Map<IEnumerable<GenreDto>>(genres);

            return Ok(genresDto);
        }

        [HttpGet]
        public IActionResult GetGenreById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid Id");
            }

            var genre = db.Genres.Find(id);

            if (genre == null)
            {
                return NotFound("Genre not found");
            }

            var genreDto = mapper.Map<GenreDto>(genre);

            return Ok(genreDto);
        }

        [HttpPost]
        public IActionResult Create(CreateGenreDto createGenre)
        {
            var genre = mapper.Map<Genre>(createGenre);

            db.Genres.Add(genre);
            db.SaveChanges();

            return Ok();
        }

        [HttpPut]
        public IActionResult Update(EditGenreDto editGenre)
        {
            var genre = mapper.Map<Genre>(editGenre);

            db.Genres.Update(genre);
            db.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if(id < 0)
            {
                return BadRequest("Invalid Id");
            }

            var genre = db.Genres.Find(id);

            if(genre == null)
            {
                return NotFound("Genre not found");
            }

            db.Genres.Remove(genre);
            db.SaveChanges();

            return Ok();
        }

    }
}
