using BusinessLogic.DTOs.GenreDto;
using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Project_Cinema_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IGenreService genreService;

        public GenresController(IGenreService genreService)
        {
            this.genreService = genreService;
        }

        [HttpGet("All")]
        public IActionResult GetGenres()
        {
            return Ok(genreService.GetAll());
        }

        [HttpGet]
        public IActionResult GetGenreById(int id)
        {
            genreService.Get(id);

            return Ok(genreService.Get(id));
        }

        [HttpPost]
        public IActionResult Create(CreateGenreDto createGenre)
        {
            genreService.Create(createGenre);

            return Ok();
        }

        [HttpPut]
        public IActionResult Edit(EditGenreDto editGenre)
        {
            genreService.Edit(editGenre);

            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            genreService.Delete(id);

            return NoContent();
        }

    }
}
