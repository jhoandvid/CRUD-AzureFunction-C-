using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users.Domain.Dto;
using Users.Domain.Interfaces;
using Users.Domain.Model;

namespace User.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private List<UserModel> users;
        private readonly UserContext _context;

        public UserRepository(UserContext context)
        {
            _context = context;
            users = new List<UserModel>();
        }

       

        public async Task<UserModel> CreateUser(UserModel userModel)
        {
            _context.Add(userModel);
            await _context.SaveChangesAsync();
            return userModel;
        }

        public List<UserModel> GetAllUser()
        {
            return users;
        }

        public UserModel? GetUserById(int id)
        {
            var user= users.FirstOrDefault(x=>x.Id== id);
            if (user == null)
            {
                return null;
            }
            return user;
        }

        public UserModel? UpdateUser(int id, UserModel userModel)
        {
            var user= this.GetUserById(id);

            if(user == null)
            {
                return null;
            }
            user.Document = userModel.Document;
            user.LastName = userModel.LastName;
            user.BirthDay= userModel.BirthDay;
            user.Name = userModel.Name;

            return user;
        }

      
    }
}
