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
        Task<List<UserModel>> GetAllUser();
        Task<UserModel?> GetUserById(int id);
        Task<UserModel?> UpdateUser(UserModel userModel);
    }
}
