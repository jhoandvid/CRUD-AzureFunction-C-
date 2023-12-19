using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users.Domain.Dto;
using Users.Domain.Model;

namespace User.Infrastructure.Persistence.Mappings
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile() {
            CreateMap<UserModel, UserDtoResponse>().ReverseMap();
            CreateMap<UserCreateDto, UserModel>();
            CreateMap<UserUpdateDto, UserModel>();
        }
    }
}
