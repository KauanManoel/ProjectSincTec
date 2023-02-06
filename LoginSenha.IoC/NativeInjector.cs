using Microsoft.Extensions.DependencyInjection;
using System;
using LoginSenha.Application.Interfaces;
using LoginSenha.Application.Services;
using LoginSenha.Data.Repositories;
using LoginSenha.Domain.Interfaces;

namespace LoginSenha.IoC
{
    public static class NativeInjector
    {
        public static void RegisterServices(IServiceCollection services)
        {
            #region Services

            services.AddScoped<IUserService, UserService>();

            #endregion

            #region Repositories

            services.AddScoped<IUserRepository, UserRepository>();

            #endregion
        }
    }
}
