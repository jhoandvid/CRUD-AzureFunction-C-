using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users.Domain.Dto;

namespace Users.Domain.validators
{
    public class UserUpdateDtoValidator: AbstractValidator<UserUpdateDto>
    {
        public UserUpdateDtoValidator() {
            RuleFor(m=>m.Name).NotEmpty();
        }
    }
}
