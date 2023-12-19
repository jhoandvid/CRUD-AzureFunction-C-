

using Users.Domain.Dto;
using Users.Domain.Model;

namespace User.Application.Interfaces
{
    public interface IUserApplication
    {
        List<UserDtoResponse> GetAllUser();
        UserDtoResponse CreateUser(UserCreateDto userCreateDto);
        UserDtoResponse? GetUserById(int id);
        UserDtoResponse? UpdateUser(int id, UserUpdateDto userModel);

    }
}
