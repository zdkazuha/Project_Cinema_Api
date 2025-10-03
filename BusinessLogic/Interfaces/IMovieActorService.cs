using BusinessLogic.DTOs.MovieActorDto;

namespace BusinessLogic.Interfaces
{
    public interface IMovieActorService
    {
        IList<MovieActorDto> GetAll(string? ActorName, string? MovieTitle, string? CharacterName);
        MovieActorDto? Get(int id);
        void Create(CreateMovieActorDto model);
        void Edit(EditMovieActorDto model);
        void Delete(int id);
    }
}
