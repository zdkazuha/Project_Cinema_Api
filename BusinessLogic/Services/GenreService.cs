using AutoMapper;
using BusinessLogic.DTOs.GenreDto;
using BusinessLogic.Interfaces;
using DataAccess.Data.Entities;
using DataAccess.Repositories;
using LinqKit;
using System.Net;

namespace BusinessLogic.Services
{
    public class GenreService : IGenreService
    {
        private readonly IRepository<Genre> repo;
        private readonly IMapper mapper;

        public GenreService(IRepository<Genre> repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }

        public async Task Create(CreateGenreDto model)
        {
            var genre = mapper.Map<Genre>(model);

            await repo.AddAsync(genre);
        }

        public async Task Delete(int id)
        {
            if (id < 0)
                throw new HttpException("Id can`t be negative ", HttpStatusCode.BadRequest);

            var genre = await repo.GetByIdAsync(id);

            if (genre == null)
                throw new HttpException($"Genre with id-{id} not found ", HttpStatusCode.NotFound);

            await repo.DeleteAsync(genre);
        }

        public async Task Edit(EditGenreDto model)
        {
            var genre = mapper.Map<Genre>(model);

            await repo.UpdateAsync(genre);
        }

        public async Task<IList<GenreDto>> GetAll(string? GenreName, int pageNumber = 1)
        {
            var filterEx = PredicateBuilder.New<Genre>(true);

            if (GenreName != null)
                filterEx.And(g => g.Name.Contains(GenreName.ToLower()));

            var genresPaged = await repo.GetAllAsync(pageNumber, 5, filterEx);

            return mapper.Map<IList<GenreDto>>(genresPaged);
        }

        public async Task<GenreDto?> Get(int id)
        {
            if (id <= 0)
                throw new HttpException("Id can`t be negative ", HttpStatusCode.BadRequest);

            var genre = await repo.GetByIdAsync(id);

            if (genre == null)
                throw new HttpException($"Genre with id-{id} not found ", HttpStatusCode.NotFound);

            var genreDto = mapper.Map<GenreDto>(genre);

            return genreDto;
        }
    }
}
