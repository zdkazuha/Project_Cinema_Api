using BusinessLogic.DTOs.GenreDto;

namespace BusinessLogic.Interfaces
{
    public interface IGenreService
    {
        IList<GenreDto> GetAll(string? GenreName);
        GenreDto? Get(int id);
        void Create(CreateGenreDto model);
        void Edit(EditGenreDto model);
        void Delete(int id);
    }
}
