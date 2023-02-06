using System;
using System.Collections.Generic;
using System.Text;
using LoginSenha.Data.Context;
using LoginSenha.Domain.Entities;
using LoginSenha.Domain.Interfaces;

namespace LoginSenha.Data.Repositories
{
    public class UserRepository: Repository<User>, IUserRepository
    {

        public UserRepository(LoginSenhaContext context)
            : base(context) { }

        public IEnumerable<User> GetAll()
        {
            return Query(x => !x.IsDeleted);
        }

    }
}
