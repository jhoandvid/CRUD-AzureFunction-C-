using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users.Domain.Dto;

namespace Users.Domain.validators
{
    public class UserCreateDtoValidator:AbstractValidator<UserCreateDto>
    {
        public UserCreateDtoValidator() {
            RuleFor(m => m.Name).NotNull().WithMessage("El nombre no puede ser nulo").NotEmpty().WithMessage("El nombre no puede ser vacio");

        }
    }
}
