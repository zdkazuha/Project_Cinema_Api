using BusinessLogic.DTOs.GenreDto;
using BusinessLogic.Interfaces;
using DataAccess.Data.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Project_Cinema_Api.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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
        public async Task<ActionResult<IEnumerable<GenreDto>>> GetGenres(string? GenreName, int numberPage = 1)
        {
            return Ok(await genreService.GetAll(GenreName, numberPage));
        }

        [HttpGet]
        public async Task<ActionResult<GenreDto>> GetGenreById(int id)
        {
            await genreService.Get(id);

            return Ok(genreService.Get(id));
        }

        [HttpPost]
        public async Task<ActionResult<Genre>> Create(CreateGenreDto createGenre)
        {
            await genreService.Create(createGenre);

            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult<GenreDto>> Edit(EditGenreDto editGenre)
        {
            await genreService.Edit(editGenre);

            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult<GenreDto>> Delete(int id)
        {
            await genreService.Delete(id);

            return NoContent();
        }

    }
}
