using BusinessLogic.DTOs.MovieDto;
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
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService movieService;

        public MoviesController(IMovieService movieService)
        {
            this.movieService = movieService;
        }

        [HttpGet("All")]
        public async Task<ActionResult<IEnumerable<MovieDto>>> GetMovies(string? Title, string? Overview, double? Rating, bool? sortByBudgetAscending, int pageNumber = 1)
        {
            if(pageNumber <= 0)
            {
                return BadRequest("Page number must be greater than 0.");
            }

            return Ok(await movieService.GetAll(Title, Overview, Rating, sortByBudgetAscending, pageNumber));
        }

        [HttpGet]
        public async Task<ActionResult<MovieDto>> GetMovieById(int id)
        {
            return Ok(await movieService.Get(id));
        }

        [HttpPost]
        public async Task<ActionResult<Movie>> Created(CreateMovieDto createMovie)
        {
            await movieService.Create(createMovie);

            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult<MovieDto>> Edit(EditMovieDto editMovie)
        {
            await movieService.Edit(editMovie);

            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult<MovieDto>> Delete(int id)
        {
            await movieService.Delete(id);

            return NoContent();
        }
    }
}
