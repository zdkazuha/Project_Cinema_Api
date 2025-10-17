using BusinessLogic.DTOs.ActorDto;
using BusinessLogic.Interfaces;
using DataAccess.Data.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project_Cinema_Api.Helpers;

namespace Project_Cinema_Api.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class ActorsController : ControllerBase
    {
        private readonly IActorService actorService;

        public ActorsController(IActorService actorService)
        {
            this.actorService = actorService;
        }

        [HttpGet("All")]
        public async Task<ActionResult<IEnumerable<ActorDto>>> GetActors(string? ActorName, int numberPage = 1)
        {
            return Ok(await actorService.GetAll(ActorName, numberPage));
        }

        [HttpGet]
        public async Task<ActionResult<ActorDto>> GetActorById(int id)
        {
           return Ok(await actorService.Get(id));
        }

        [HttpPost]
        public async Task<ActionResult<Actor>> Create(CreateActorDto createActor)
        {
            await actorService.Create(createActor);

            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult<IEnumerable<ActorDto>>> Update(EditActorDto editActor)
        {
            await actorService.Edit(editActor);

            return Ok();
        }

        [Authorize(Roles = Roles.ADMIN, AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await actorService.Delete(id);

            return NoContent();
        }
    }
}
