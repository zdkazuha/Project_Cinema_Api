using BusinessLogic.DTOs.MovieActorDto;

namespace BusinessLogic.Interfaces
{
    public interface IMovieActorService
    {
        Task<IList<MovieActorDto>> GetAll(string? ActorName, string? MovieTitle, string? CharacterName, int pageNumber);
        Task<MovieActorDto?> Get(int id);
        Task Create(CreateMovieActorDto model);
        Task Edit(EditMovieActorDto model);
        Task Delete(int id);
    }
}
