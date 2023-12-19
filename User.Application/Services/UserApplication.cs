using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Application.Interfaces;
using Users.Domain.Dto;
using Users.Domain.Interfaces;
using Users.Domain.Model;

namespace User.Application.Services
{
    public class UserApplication : IUserApplication
    {
        private readonly IUserRepository _userRepository;
        public UserApplication(IUserRepository userRepository) {
            _userRepository = userRepository;
        }

        public UserDtoResponse CreateUser(UserCreateDto userCreateDto)
        {
            UserModel userModel= new UserModel() { Name=userCreateDto.Name, BirthDay= userCreateDto.BirthDay, Document= userCreateDto.Document, LastName= userCreateDto.LastName};
            var user=_userRepository.CreateUser(userModel);
            var userDtoResponse = new UserDtoResponse() { Id = user.Id, BirthDay = user.BirthDay, Document = user.Document, LastName = user.LastName, Name = user.Name };
            return userDtoResponse;
        }

        public List<UserDtoResponse> GetAllUser()
        {
            var response = _userRepository.GetAllUser();

            var responseDto = new List<UserDtoResponse>();

            foreach (var user in response)
            {
                responseDto.Add(new UserDtoResponse() { Id = user.Id, Name = user.Name, Document = user.Document, BirthDay = user.BirthDay, LastName = user.LastName });
            }

            return responseDto;
        }

        public UserDtoResponse? GetUserById(int id)
        {
            var user= _userRepository.GetUserById(id);
            if (user == null)
            {
                return null;
            }
            var userDto = new UserDtoResponse() { BirthDay = user.BirthDay, Document = user.Document, LastName = user.LastName, Name = user.Name, Id = user.Id };
            return userDto; 
        }

        public UserDtoResponse? UpdateUser(int id, UserUpdateDto userUpdateModel)
        {
            var userModel = new UserModel() { BirthDay = userUpdateModel.BirthDay, Document = userUpdateModel.Document, LastName = userUpdateModel.LastName, Name = userUpdateModel.LastName};
            var userUpdate= _userRepository.UpdateUser(id, userModel);
            if(userUpdate == null)
            {
                return null;
            }
            var responseDto = new UserDtoResponse() { Name = userUpdate.Name, LastName = userUpdate.LastName, Document = userUpdate.LastName, BirthDay = userUpdate.BirthDay, Id= userUpdate.Id };
            return responseDto;
        }
    }
}
