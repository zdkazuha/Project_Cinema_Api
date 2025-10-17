using AutoMapper;
using BusinessLogic.DTOs.ActorDto;
using BusinessLogic.Helpers;
using BusinessLogic.Interfaces;
using DataAccess.Data;
using DataAccess.Data.Entities;
using System.Net;

namespace BusinessLogic.Services
{
    public class ActorService : IActorService
    {
        private readonly CinemaDbContext db;
        private readonly IMapper mapper;

        public ActorService(CinemaDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task Create(CreateActorDto model)
        {
            var actor = mapper.Map<Actor>(model);

            db.Actors.Add(actor);
            await db.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            if (id < 0)
                throw new HttpException("Id can`t be negative ", HttpStatusCode.BadRequest);

            var actor = db.Actors.Find(id);

            if (actor == null)
                throw new HttpException($"Actor with id-{id} not found ", HttpStatusCode.NotFound);

            db.Actors.Remove(actor);
            await db.SaveChangesAsync();
        }

        public async Task Edit(EditActorDto model)
        {
            var actor = mapper.Map<Actor>(model);

            db.Actors.Update(actor);
            await db.SaveChangesAsync();
        }

        public async Task<ActorDto?> Get(int id)
        {
            if (id <= 0)
                throw new HttpException("Id can`t be negative ", HttpStatusCode.BadRequest);

            var actor = await db.Actors.FindAsync(id);

            if (actor == null)
                throw new HttpException($"Actor with id-{id} not found ", HttpStatusCode.NotFound);

            var actorDto = mapper.Map<ActorDto>(actor);

            return actorDto;
        }

        public async Task<IList<ActorDto>> GetAll(string? ActorName, int pageNumber = 1)
        {
            IQueryable<Actor> actors = db.Actors;

            if (ActorName != null)
            {
                actors = db.Actors
                    .Where(x => x.Name.Contains(ActorName.ToLower()));
            }

            var actorsPaged = await PagedList<Actor>.CreateAsync(db.Actors, pageNumber, 5);

            return mapper.Map<IList<ActorDto>>(actorsPaged);
        }
    }
}
