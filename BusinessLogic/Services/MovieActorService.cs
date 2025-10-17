using AutoMapper;
using BusinessLogic.DTOs.MovieActorDto;
using BusinessLogic.Interfaces;
using DataAccess.Data.Entities;
using DataAccess.Repositories;
using LinqKit;
using System.Net;

namespace BusinessLogic.Services
{
    public class MovieActorService : IMovieActorService
    {
        private readonly IRepository<MovieActor> repo;
        private readonly IMapper mapper;

        public MovieActorService(IRepository<MovieActor> repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }

        public async Task Create(CreateMovieActorDto model)
        {
            var movieActor = mapper.Map<MovieActor>(model);

            await repo.AddAsync(movieActor);
        }

        public async Task Delete(int id)
        {
            if (id < 0)
                throw new HttpException("Id can`t be negative ", HttpStatusCode.BadRequest);

            var movieActor = await repo.GetByIdAsync(id);

            if (movieActor == null)
                throw new HttpException($"Movie Actor with id-{id} not found ", HttpStatusCode.NotFound);

            await repo.DeleteAsync(movieActor);
        }

        public async Task Edit(EditMovieActorDto model)
        {
            var movieActor = mapper.Map<MovieActor>(model);

            await repo.UpdateAsync(movieActor);
        }

        public async Task<IList<MovieActorDto>> GetAll(string? ActorName, string? MovieTitle, string? CharacterName, int pageNumber = 1)
        {
            var filterEx = PredicateBuilder.New<MovieActor>(true);

            if (ActorName != null)
                filterEx.And(x => x.Actor.Name.Contains(ActorName.ToLower()));

            if (MovieTitle != null)
                filterEx.And(x => x.Movie.Title.Contains(MovieTitle.ToLower()));

            if (CharacterName != null)
                filterEx.And(x => x.CharacterName.Contains(CharacterName.ToLower()));

            var movieActorsPaged = await repo.GetAllAsync(pageNumber, 5, filterEx, "Movie", "Actor");

            return movieActorsPaged.Select(ma => mapper.Map<MovieActorDto>(ma)).ToList();
        }

        public async Task<MovieActorDto?> Get(int id)
        {
            if (id <= 0)
                throw new HttpException("Id can`t be negative ", HttpStatusCode.BadRequest);

            var movieActor = await repo.GetByIdAsync(id, "Movie", "Actor");

            if (movieActor == null)
                throw new HttpException($"Movie Actor with id-{id} not found ", HttpStatusCode.NotFound);

            var movieActorDto = mapper.Map<MovieActorDto>(movieActor);

            return movieActorDto;
        }
    }
}
