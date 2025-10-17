using BusinessLogic.DTOs.GenreDto;
using BusinessLogic.Interfaces;
using DataAccess.Data.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project_Cinema_Api.Helpers;

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
        public async Task<ActionResult<IEnumerable<GenreDto>>> GetGenres(string? GenreName, int numberPage = 1)
        {
            return Ok(await genreService.GetAll(GenreName, numberPage));
        }

        [HttpGet]
        public async Task<ActionResult<GenreDto>> GetGenreById(int id)
        {
            return Ok(await genreService.Get(id));
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<Genre>> Create(CreateGenreDto createGenre)
        {
            await genreService.Create(createGenre);

            return Ok();
        }

        [HttpPut]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<GenreDto>> Edit(EditGenreDto editGenre)
        {
            await genreService.Edit(editGenre);

            return Ok();
        }

        [HttpDelete]
        [Authorize(Roles = Roles.ADMIN, AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<GenreDto>> Delete(int id)
        {
            await genreService.Delete(id);

            return NoContent();
        }

    }
}
