using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using LoginSenha.Application.ViewModels;
using LoginSenha.Domain.Entities;

namespace LoginSenha.Application.AutoMapper
{
    public class AutoMapperSetup: Profile
    {
        public AutoMapperSetup()
        {
            #region ViewModelToDomain

            CreateMap<UserViewModel, User>();

            #endregion

            #region DomainToViewModel

            CreateMap<User, UserViewModel>();

            #endregion
        }
    }
}
