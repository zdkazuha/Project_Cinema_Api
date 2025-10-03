using AutoMapper;
using BusinessLogic.DTOs.ActorDto;
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

        public void Create(CreateActorDto model)
        {
            var actor = mapper.Map<Actor>(model);

            db.Actors.Add(actor);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            if (id < 0)
                throw new HttpException("Id can`t be negative ", HttpStatusCode.BadRequest);

            var actor = db.Actors.Find(id);

            if (actor == null)
                throw new HttpException($"Actor with id-{id} not found ", HttpStatusCode.NotFound);

            db.Actors.Remove(actor);
            db.SaveChanges();
        }

        public void Edit(EditActorDto model)
        {
            var actor = mapper.Map<Actor>(model);

            db.Actors.Update(actor);
            db.SaveChanges();
        }

        public ActorDto? Get(int id)
        {
            if (id <= 0)
                throw new HttpException("Id can`t be negative ", HttpStatusCode.BadRequest);

            var actor = db.Actors.Find(id);

            if (actor == null)
                throw new HttpException($"Actor with id-{id} not found ", HttpStatusCode.NotFound);

            var actorDto = mapper.Map<ActorDto>(actor);

            return actorDto;
        }

        public IList<ActorDto> GetAll(string? ActorName)
        {
            IQueryable<Actor> actors = db.Actors;

            if (ActorName != null)
            {
                actors = db.Actors
                    .Where(x => x.Name.Contains(ActorName.ToLower()));
            }

            var actorsDto = mapper.Map<IList<ActorDto>>(actors.ToList());

            return actorsDto;
        }
    }
}
