using BusinessLogic.DTOs.ActorDto;

namespace BusinessLogic.Interfaces
{
    public interface IActorService
    {
        IList<ActorDto> GetAll();
        ActorDto? Get(int id);
        void Create(CreateActorDto model);
        void Edit(EditActorDto model);
        void Delete(int id);
    }
}
