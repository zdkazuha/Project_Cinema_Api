using BusinessLogic.DTOs.MovieActorDto;
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
    public class MovieActorsController : ControllerBase
    {
        private readonly IMovieActorService movieActorService;

        public MovieActorsController(IMovieActorService movieActorService)
        {
            this.movieActorService = movieActorService;
        }

        [HttpGet("All")]
        public async Task<ActionResult<IEnumerable<MovieActorDto>>> GetMovieActors(string? ActorName, string? MovieTitle, string? CharacterName, int numberPage = 1)
        {
            return Ok(await movieActorService.GetAll(ActorName, MovieTitle, CharacterName, numberPage));
        }

        [HttpGet]
        public async Task<ActionResult<MovieActorDto>> GetMovieActorById(int id)
        {
            return Ok(await movieActorService.Get(id));
        }

        [HttpPost]
        public async Task<ActionResult<MovieActor>> Create(CreateMovieActorDto createMovieActor)
        {
            await movieActorService.Create(createMovieActor);

            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult<MovieActorDto>> Edit(EditMovieActorDto editMovieActor)
        {
            await movieActorService.Edit(editMovieActor);

            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult<MovieActorDto>> Delete(int id)
        {
            await movieActorService.Delete(id);

            return NoContent();
        }
    }
}
