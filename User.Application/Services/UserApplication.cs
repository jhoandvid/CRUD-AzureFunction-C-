using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Application.Interfaces;
using AutoMapper;
using Users.Domain.Dto;
using Users.Domain.Interfaces;
using Users.Domain.Model;

namespace User.Application.Services
{
    public class UserApplication : IUserApplication
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        public UserApplication(IMapper mapper, IUserRepository userRepository) {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<UserDtoResponse> CreateUser(UserCreateDto userCreateDto)
        {
            var userModel=_mapper.Map<UserModel>(userCreateDto);
            var user=await _userRepository.CreateUser(userModel);
            return _mapper.Map<UserDtoResponse>(user);
        }

        public async Task<List<UserDtoResponse>> GetAllUser()
        {
            var response = await _userRepository.GetAllUser();
            return _mapper.Map<List<UserDtoResponse>>(response);
        }

        public async Task<UserDtoResponse?> GetUserById(int id)
        {
            var user= await _userRepository.GetUserById(id);
            if (user == null)
            {
                return null;
            }
            return _mapper.Map<UserDtoResponse>(user); 
        }

        public async Task<UserDtoResponse?> UpdateUser(int id, UserUpdateDto userUpdateModel)
        {
         
            var user = await _userRepository.GetUserById(id);
            
            if(user == null)
            {
                return null;
            }

            user = _mapper.Map(userUpdateModel, user);

            var userModel = _mapper.Map<UserModel>(user);
            
            if(userModel == null)
            {
                return null;
            }
            var userUpdate = await _userRepository.UpdateUser(userModel);
            return _mapper.Map<UserDtoResponse>(userUpdate);
        }
    }
}
