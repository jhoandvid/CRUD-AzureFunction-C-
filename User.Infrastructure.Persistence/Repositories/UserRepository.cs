using Microsoft.EntityFrameworkCore;
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
        private readonly UserContext _context;

        public UserRepository(UserContext context)
        {
            _context = context;
        }

       

        public async Task<UserModel> CreateUser(UserModel userModel)
        {
            _context.Add(userModel);
            await _context.SaveChangesAsync();
            return userModel;
        }

        public async Task<List<UserModel>> GetAllUser()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<UserModel?> GetUserById(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<UserModel?> UpdateUser(UserModel userModel)
        {
            _context.Update(userModel);
            await _context.SaveChangesAsync();
            return userModel;
        }

       
    }
}
