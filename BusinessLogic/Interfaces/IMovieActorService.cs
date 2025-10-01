using BusinessLogic.DTOs.MovieActorDto;

namespace BusinessLogic.Interfaces
{
    public interface IMovieActorService
    {
        IList<MovieActorDto> GetAll();
        MovieActorDto? Get(int id);
        void Create(CreateMovieActorDto model);
        void Edit(EditMovieActorDto model);
        void Delete(int id);
    }
}
