using AutoMapper;
using BusinessLogic.DTOs.ActorDto;
using BusinessLogic.DTOs.ActorDto;
using DataAccess.Data;
using DataAccess.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Project_Cinema_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorsController : ControllerBase
    {
        private readonly CinemaDbContext db;
        private readonly IMapper mapper;

        public ActorsController(CinemaDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        [HttpGet("All")]
        public IActionResult GetActors()
        {
            var actors = db.Actors.ToList();

            var actorsDto = mapper.Map<IEnumerable<ActorDto>>(actors);

            return Ok(actorsDto);
        }

        [HttpGet]
        public IActionResult GetActorById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid Id");
            }

            var actor = db.Actors.Find(id);

            if (actor == null)
            {
                return NotFound("Actor not found");
            }

            var actorDto = mapper.Map<ActorDto>(actor);

            return Ok(actorDto);
        }

        [HttpPost]
        public IActionResult Create(CreateActorDto createActor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var actor = mapper.Map<Actor>(createActor);

            db.Actors.Add(actor);
            db.SaveChanges();

            return Ok();
        }

        [HttpPut]
        public IActionResult Update(EditActorDto editActor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var actor = mapper.Map<Actor>(editActor);

            db.Actors.Update(actor);
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

            var actor = db.Actors.Find(id);

            if (actor == null)
            {
                return NotFound("Actor not found");
            }

            db.Actors.Remove(actor);
            db.SaveChanges();

            return Ok();
        }
    }
}
