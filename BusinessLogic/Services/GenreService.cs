using AutoMapper;
using BusinessLogic.DTOs.GenreDto;
using BusinessLogic.Interfaces;
using DataAccess.Data;

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
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(EditGenreDto model)
        {
            throw new NotImplementedException();
        }

        public IList<GenreDto> GetAll()
        {
            var genres = db.Genres.ToList();

            var genresDto = mapper.Map<IList<GenreDto>>(genres);

            return genresDto;
        }

        public GenreDto? Get(int id)
        {
            if (id <= 0) return null;

            var genre = db.Genres.Find(id);

            if (genre == null) return null;

            var genreDto = mapper.Map<GenreDto>(genre);

            return genreDto;
        }
    }
}
