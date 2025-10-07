using AutoMapper;
using BusinessLogic.DTOs.GenreDto;
using BusinessLogic.Helpers;
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

        public async Task Create(CreateGenreDto model)
        {
            var genre = mapper.Map<Genre>(model);

            db.Genres.Add(genre);
            await db.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            if (id < 0)
                throw new HttpException("Id can`t be negative ", HttpStatusCode.BadRequest);

            var genre = db.Genres.Find(id);

            if (genre == null)
                throw new HttpException($"Genre with id-{id} not found ", HttpStatusCode.NotFound);

            db.Genres.Remove(genre);
            await db.SaveChangesAsync();
        }

        public async Task Edit(EditGenreDto model)
        {
            var genre = mapper.Map<Genre>(model);

            db.Genres.Update(genre);
            await db.SaveChangesAsync();
        }

        public async Task<IList<GenreDto>> GetAll(string? GenreName, int pageNumber = 1)
        {
            IQueryable<Genre> genres = db.Genres;

            if (GenreName != null)
            {
                genres = db.Genres
                    .Where(g => g.Name.Contains(GenreName.ToLower()));
            }

            var genresPaged = await PagedList<Genre>.CreateAsync(genres, pageNumber, 5);

            return mapper.Map<IList<GenreDto>>(genresPaged);
        }

        public async Task<GenreDto?> Get(int id)
        {
            if (id <= 0)
                throw new HttpException("Id can`t be negative ", HttpStatusCode.BadRequest);

            var genre = await db.Genres.FindAsync(id);

            if (genre == null)
                throw new HttpException($"Genre with id-{id} not found ", HttpStatusCode.NotFound);

            var genreDto = mapper.Map<GenreDto>(genre);

            return genreDto;
        }
    }
}
