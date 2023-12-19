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

        public UserDtoResponse CreateUser(UserCreateDto userCreateDto)
        {
            var userModel=_mapper.Map<UserModel>(userCreateDto);
            var user=_userRepository.CreateUser(userModel);
            return _mapper.Map<UserDtoResponse>(user);
        }

        public List<UserDtoResponse> GetAllUser()
        {
            var response = _userRepository.GetAllUser();
            return _mapper.Map<List<UserDtoResponse>>(response);
        }

        public UserDtoResponse? GetUserById(int id)
        {
            var user= _userRepository.GetUserById(id);
            if (user == null)
            {
                return null;
            }
            return _mapper.Map<UserDtoResponse>(user); 
        }

        public UserDtoResponse? UpdateUser(int id, UserUpdateDto userUpdateModel)
        {
            var userModel = _mapper.Map<UserModel>(userUpdateModel);

            var userUpdate= _userRepository.UpdateUser(id, userModel);
            if(userUpdate == null)
            {
                return null;
            }
            return _mapper.Map<UserDtoResponse>(userUpdate);
        }
    }
}
