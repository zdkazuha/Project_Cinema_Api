using BusinessLogic.DTOs.UserDto;

namespace BusinessLogic.Interfaces
{
    public interface IUserService
    {
        Task<IList<UserDto>> GetAll(string? UserName, int pageNumber);
        Task<UserDto?> Get(int id);
        Task Create(CreateUserDto model);
        Task Edit(EditUserDto model);
        Task Delete(int id);
    }
}
