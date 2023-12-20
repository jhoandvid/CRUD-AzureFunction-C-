

using Users.Domain.Dto;
using Users.Domain.Model;

namespace User.Application.Interfaces
{
    public interface IUserApplication
    {
        Task<List<UserDtoResponse>> GetAllUser();
        Task<UserDtoResponse> CreateUser(UserCreateDto userCreateDto);
        Task<UserDtoResponse?> GetUserById(int id);
        Task<UserDtoResponse?> UpdateUser(int id, UserUpdateDto userModel);

    }
}
