using System;
using System.Collections.Generic;
using System.Text;
using LoginSenha.Domain.Entities;

namespace LoginSenha.Domain.Interfaces
{
    public interface IUserRepository: IRepository<User>
    {
        IEnumerable<User> GetAll();
    }
}
