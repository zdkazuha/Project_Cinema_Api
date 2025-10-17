using AutoMapper;
using BusinessLogic.DTOs.ActorDto;
using BusinessLogic.Interfaces;
using DataAccess.Data.Entities;
using DataAccess.Repositories;
using LinqKit;
using System.Net;

namespace BusinessLogic.Services
{
    public class ActorService : IActorService
    {
        private readonly IRepository<Actor> repo;
        private readonly IMapper mapper;

        public ActorService(IRepository<Actor> repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }

        public async Task Create(CreateActorDto model)
        {
            var actor = mapper.Map<Actor>(model);

            await repo.AddAsync(actor);
        }

        public async Task Delete(int id)
        {
            if (id < 0)
                throw new HttpException("Id can`t be negative ", HttpStatusCode.BadRequest);

            var actor = await repo.GetByIdAsync(id);

            if (actor == null)
                throw new HttpException($"Actor with id-{id} not found ", HttpStatusCode.NotFound);

            await repo.DeleteAsync(actor);
        }

        public async Task Edit(EditActorDto model)
        {
            var actor = mapper.Map<Actor>(model);

            await repo.UpdateAsync(actor);
        }

        public async Task<IList<ActorDto>> GetAll(string? ActorName, int pageNumber = 1)
        {
            var filterEx = PredicateBuilder.New<Actor>(true);

            if (ActorName != null)
                filterEx.And(x => x.Name.Contains(ActorName.ToLower()));

            var actorsPaged = await repo.GetAllAsync(pageNumber, 5, filterEx);

            return mapper.Map<IList<ActorDto>>(actorsPaged);
        }
        public async Task<ActorDto?> Get(int id)
        {
            if (id <= 0)
                throw new HttpException("Id can`t be negative ", HttpStatusCode.BadRequest);

            var actor = await repo.GetByIdAsync(id);

            if (actor == null)
                throw new HttpException($"Actor with id-{id} not found ", HttpStatusCode.NotFound);

            var actorDto = mapper.Map<ActorDto>(actor);

            return actorDto;
        }
    }
}
