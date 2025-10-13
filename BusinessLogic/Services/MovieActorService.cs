using AutoMapper;
using BusinessLogic.DTOs.MovieActorDto;
using BusinessLogic.Helpers;
using BusinessLogic.Interfaces;
using DataAccess.Data;
using DataAccess.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace BusinessLogic.Services
{
    public class MovieActorService : IMovieActorService
    {
        private readonly CinemaDbContext db;
        private readonly IMapper mapper;

        public MovieActorService(CinemaDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task Create(CreateMovieActorDto model)
        {
            var movieActor = mapper.Map<MovieActor>(model);

            db.MovieActors.Add(movieActor);
            await db.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            if (id < 0)
                throw new HttpException("Id can`t be negative ", HttpStatusCode.BadRequest);

            var movieActor = db.MovieActors.Find(id);

            if (movieActor == null)
                throw new HttpException($"Movie Actor with id-{id} not found ", HttpStatusCode.NotFound);

            db.MovieActors.Remove(movieActor);
            await db.SaveChangesAsync();
        }

        public async Task Edit(EditMovieActorDto model)
        {
            var movieActor = mapper.Map<MovieActor>(model);

            db.MovieActors.Update(movieActor);
            await db.SaveChangesAsync();
        }

        public async Task<IList<MovieActorDto>> GetAll(string? ActorName, string? MovieTitle, string? CharacterName, int pageNumber = 1)
        {
            IQueryable<MovieActor> movieActors = db.MovieActors
                .Include(x => x.Movie)
                .Include(x => x.Actor);

            if (ActorName != null)
            {
                movieActors = movieActors
                    .Where(x => x.Actor.Name.Contains(ActorName.ToLower()));
            }

            if (MovieTitle != null)
            {
                movieActors = movieActors
                    .Where(x => x.Movie.Title.Contains(MovieTitle.ToLower()));
            }

            if (CharacterName != null)
            {
                movieActors = movieActors
                    .Where(x => x.CharacterName.Contains(CharacterName.ToLower()));
            }

            var movieActorsPaged = await PagedList<MovieActor>.CreateAsync(movieActors, pageNumber, 5);
            return movieActorsPaged.Select(ma => mapper.Map<MovieActorDto>(ma)).ToList();
        }

        public async Task<MovieActorDto?> Get(int id)
        {
            if (id <= 0)
                throw new HttpException("Id can`t be negative ", HttpStatusCode.BadRequest);

            var movieActor = await db.MovieActors
                .Include(ma => ma.Movie)
                .Include(ma => ma.Actor)
                .FirstOrDefaultAsync(ma => ma.Id == id);

            if (movieActor == null)
                throw new HttpException($"Movie Actor with id-{id} not found ", HttpStatusCode.NotFound);

            var movieActorDto = mapper.Map<MovieActorDto>(movieActor);

            return movieActorDto;
        }
    }
}
