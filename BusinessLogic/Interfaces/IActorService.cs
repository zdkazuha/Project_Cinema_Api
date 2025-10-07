using BusinessLogic.DTOs.ActorDto;

namespace BusinessLogic.Interfaces
{
    public interface IActorService
    {
        Task<IList<ActorDto>> GetAll(string? ActorName, int pageNumber);
        Task<ActorDto?> Get(int id);
        Task Create(CreateActorDto model);
        Task Edit(EditActorDto model);
        Task Delete(int id);
    }
}
