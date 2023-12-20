using FluentValidation;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using User.Application.Interfaces;
using User.Application.Services;
using Users.Domain.validators;
using User.Infrastructure.Persistence.Repositories;
using Users.Domain.Interfaces;
using Users.Domain.Dto;

[assembly: FunctionsStartup(typeof(User.Function.Startup))]
namespace User.Function
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //Services
            builder.Services.AddScoped<IUserApplication, UserApplication>();

            //Repository
            builder.Services.AddSingleton<IUserRepository, UserRepository>();


            //Validations
            builder.Services.AddTransient<IValidator<UserCreateDto>, UserCreateDtoValidator>();
            builder.Services.AddTransient<IValidator<UserUpdateDto>, UserUpdateDtoValidator>();
        }
    }
}
