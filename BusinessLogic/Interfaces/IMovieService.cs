using BusinessLogic.DTOs.MovieDto;

namespace BusinessLogic.Interfaces
{
    public interface IMovieService
    {
        IList<MovieDto>GetAll();
        MovieDto? Get(int id);
        void Create(CreateMovieDto model);
        void Edit(EditMovieDto model);
        void Delete(int id);
    }
}
