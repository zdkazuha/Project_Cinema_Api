using BusinessLogic.DTOs.ActorDto;
using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Project_Cinema_Api.Controllers
{
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
        public IActionResult GetActors(string? ActorName)
        {
            return Ok(actorService.GetAll(ActorName));
        }

        [HttpGet]
        public IActionResult GetActorById(int id)
        {
           return Ok(actorService.Get(id));
        }

        [HttpPost]
        public IActionResult Create(CreateActorDto createActor)
        {
            actorService.Create(createActor);

            return Ok();
        }

        [HttpPut]
        public IActionResult Update(EditActorDto editActor)
        {
            actorService.Edit(editActor);

            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            actorService.Delete(id);

            return NoContent();
        }
    }
}
