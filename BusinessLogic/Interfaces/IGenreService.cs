using BusinessLogic.DTOs.GenreDto;

namespace BusinessLogic.Interfaces
{
    public interface IGenreService
    {
        Task<IList<GenreDto>> GetAll(string? GenreName, int pageNumber);
        Task<GenreDto?> Get(int id);
        Task Create(CreateGenreDto model);
        Task Edit(EditGenreDto model);
        Task Delete(int id);
    }
}
