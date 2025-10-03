using BusinessLogic.DTOs.UserDto;

namespace BusinessLogic.Interfaces
{
    public interface IUserService
    {
        IList<UserDto> GetAll(string? UserName);
        UserDto? Get(int id);
        void Create(CreateUserDto model);
        void Edit(EditUserDto model);
        void Delete(int id);
    }
}
