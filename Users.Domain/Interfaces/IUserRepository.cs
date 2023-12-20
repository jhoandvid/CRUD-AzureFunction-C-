using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users.Domain.Dto;
using Users.Domain.Model;

namespace Users.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<UserModel> CreateUser(UserModel userModel);
        List<UserModel> GetAllUser();
        UserModel? GetUserById(int id);
        UserModel? UpdateUser(int id, UserModel userModel);
    }
}
