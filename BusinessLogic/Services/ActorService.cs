using AutoMapper;
using BusinessLogic.DTOs.ActorDto;
using BusinessLogic.Interfaces;
using DataAccess.Data;
using DataAccess.Data.Entities;

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
            if (id < 0) return;

            var actor = db.Actors.Find(id);

            if (actor == null) return;

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
            if (id <= 0) return null;

            var actor = db.Actors.Find(id);

            if (actor == null) return null;

            var actorDto = mapper.Map<ActorDto>(actor);

            return actorDto;
        }

        public IList<ActorDto> GetAll()
        {
            var actors = db.Actors.ToList();

            var actorsDto = mapper.Map<IList<ActorDto>>(actors);

            return actorsDto;
        }
    }
}
