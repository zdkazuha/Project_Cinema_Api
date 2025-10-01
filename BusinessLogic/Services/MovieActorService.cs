using AutoMapper;
using BusinessLogic.DTOs.MovieActorDto;
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

        public void Create(CreateMovieActorDto model)
        {
            var movieActor = mapper.Map<MovieActor>(model);

            db.MovieActors.Add(movieActor);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            if (id < 0)
                throw new HttpException("Id can`t be negative ", HttpStatusCode.BadRequest);

            var movieActor = db.MovieActors.Find(id);

            if (movieActor == null)
                throw new HttpException($"Movie Actor with id-{id} not found ", HttpStatusCode.NotFound);

            db.MovieActors.Remove(movieActor);
            db.SaveChanges();
        }

        public void Edit(EditMovieActorDto model)
        {
            var movieActor = mapper.Map<MovieActor>(model);

            db.MovieActors.Update(movieActor);
            db.SaveChanges();
        }

        public IList<MovieActorDto> GetAll()
        {
            var movieActors = db.MovieActors
                .Include(x => x.Movie)
                .Include(x => x.Actor)
                .ToList();

            var movieActorsDto = mapper.Map<IList<MovieActorDto>>(movieActors);

            return movieActorsDto;
        }

        public MovieActorDto? Get(int id)
        {
            if (id <= 0)
                throw new HttpException("Id can`t be negative ", HttpStatusCode.BadRequest);

            var movieActor = db.MovieActors.Find(id);

            if (movieActor == null)
                throw new HttpException($"Movie Actor with id-{id} not found ", HttpStatusCode.NotFound);

            var movieActorDto = mapper.Map<MovieActorDto>(movieActor);

            return movieActorDto;
        }
    }
}
