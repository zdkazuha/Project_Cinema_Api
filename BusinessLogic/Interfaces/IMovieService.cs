using BusinessLogic.DTOs.MovieDto;

namespace BusinessLogic.Interfaces
{
    public interface IMovieService
    {
        Task<IList<MovieDto>> GetAll(string? Title, string? Overview, double? Rating, int pageNumber);
        Task<MovieDto?> Get(int id);
        Task Create(CreateMovieDto model);
        Task Edit(EditMovieDto model);
        Task Delete(int id);
    }
}
