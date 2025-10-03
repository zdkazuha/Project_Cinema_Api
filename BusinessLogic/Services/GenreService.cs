using AutoMapper;
using BusinessLogic.DTOs.GenreDto;
using BusinessLogic.Interfaces;
using DataAccess.Data;
using DataAccess.Data.Entities;
using System.Net;

namespace BusinessLogic.Services
{
    public class GenreService : IGenreService
    {
        private readonly CinemaDbContext db;
        private readonly IMapper mapper;

        public GenreService(CinemaDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public void Create(CreateGenreDto model)
        {
            var genre = mapper.Map<Genre>(model);

            db.Genres.Add(genre);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            if (id < 0)
                throw new HttpException("Id can`t be negative ", HttpStatusCode.BadRequest);

            var genre = db.Genres.Find(id);

            if (genre == null)
                throw new HttpException($"Genre with id-{id} not found ", HttpStatusCode.NotFound);

            db.Genres.Remove(genre);
            db.SaveChanges();
        }

        public void Edit(EditGenreDto model)
        {
            var genre = mapper.Map<Genre>(model);

            db.Genres.Update(genre);
            db.SaveChanges();
        }

        public IList<GenreDto> GetAll(string? GenreName)
        {
            IQueryable<Genre> genres = db.Genres;

            if (GenreName != null)
            {
                genres = db.Genres
                    .Where(g => g.Name.Contains(GenreName.ToLower()));
            }

            var genresDto = mapper.Map<IList<GenreDto>>(genres.ToList());

            return genresDto;
        }

        public GenreDto? Get(int id)
        {
            if (id <= 0)
                throw new HttpException("Id can`t be negative ", HttpStatusCode.BadRequest);

            var genre = db.Genres.Find(id);

            if (genre == null)
                throw new HttpException($"Genre with id-{id} not found ", HttpStatusCode.NotFound);

            var genreDto = mapper.Map<GenreDto>(genre);

            return genreDto;
        }
    }
}
