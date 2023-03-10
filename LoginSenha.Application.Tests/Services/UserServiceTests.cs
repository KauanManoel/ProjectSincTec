using AutoMapper;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using LoginSenha.Application.AutoMapper;
using LoginSenha.Application.Services;
using LoginSenha.Application.ViewModels;
using LoginSenha.Domain.Entities;
using LoginSenha.Domain.Interfaces;
using Xunit;

namespace LoginSenha.Application.Tests.Services
{
    public class UserServiceTests
    {
        private UserService userService;

        public UserServiceTests()
        {
            userService = new UserService(new Mock<IUserRepository>().Object, new Mock<IMapper>().Object);
        }

        #region ValidatingSendingID

        [Fact]
        public void Post_SendingValidId()
        {
            var exception = Assert.Throws<Exception>(() => userService.Post(new UserViewModel { Id = Guid.NewGuid() }));
            Assert.Equal("UserID must be empty", exception.Message);
        }

        [Fact]
        public void GetById_SendingEmptyGuid()
        {
            var exception = Assert.Throws<Exception>(() => userService.GetById(""));
            Assert.Equal("UserID is not valid", exception.Message);
        }

        [Fact]
        public void Put_SendingEmptyGuid()
        {
            var exception = Assert.Throws<Exception>(() => userService.Put(new UserViewModel()));
            Assert.Equal("ID is invalid", exception.Message);
        }

        [Fact]
        public void Delete_SendingEmptyGuid()
        {
            var exception = Assert.Throws<Exception>(() => userService.Delete(""));
            Assert.Equal("UserID is not valid", exception.Message);
        }

        [Fact]
        public void Authenticate_SendingEmptyValues()
        {
            var exception = Assert.Throws<Exception>(() => userService.Authenticate(new UserAuthenticateRequestViewModel()));
            Assert.Equal("Email/Password are required.", exception.Message);
        }

        #endregion

        #region ValidatingCorrectObject

        [Fact]
        public void Post_SendingValidObject()
        {
            var result = userService.Post(new UserViewModel { Name = "Kauan Manoel", Email = "kauanmanoel4@gmail.com" });
            Assert.True(result);
        }

        [Fact]
        public void Get_ValidatingObject()
        {
            //Criando a lista com um objeto para que seja retornado pelo repository
            List<User> _users = new List<User>();
            _users.Add(new User { Id = Guid.NewGuid(), Name = "Kauan Maneol", Email = "kauanmanoel4@kauan.rfontes@gmail.com", DateCreated = DateTime.Now });
            //Criando um objeto mock do UserRepository e configurando para retornar a lista criada anteriormente se chamar o método GetAll()
            var _userRepository = new Mock<IUserRepository>();
            _userRepository.Setup(x => x.GetAll()).Returns(_users);
            //Criando um objeto mock do AutoMapper para que possamos converter o retorno para o tipo List<UserViewModel>()
            var _autoMapperProfile = new AutoMapperSetup();
            var _configuration = new MapperConfiguration(x => x.AddProfile(_autoMapperProfile));
            IMapper _mapper = new Mapper(_configuration);
            //Istanciando nossa classe de serviço novamente com os novos objetos mocks que criamos
            userService = new UserService(_userRepository.Object, _mapper);
            //Obtendo os valores do método Get para validar se vai retornar o objeto criado acima.
            var result = userService.Get();
            //Validando se o retorno contém uma lista com objetos.
            Assert.True(result.Count > 0);
        }

        #endregion

        #region ValidatingRequiredFields

        [Fact]
        public void Post_SendingInvalidObject()
        {
            var exception = Assert.Throws<ValidationException>(() => userService.Post(new UserViewModel { Name = "Kauan Fontes" }));
            Assert.Equal("The Email field is required.", exception.Message);
        }

        #endregion
    }
}
