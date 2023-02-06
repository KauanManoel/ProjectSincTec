using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using LoginSenha.Data.Extensions;
using LoginSenha.Data.Mappings;
using LoginSenha.Domain.Entities;

namespace LoginSenha.Data.Context
{
    public class LoginSenhaContext: DbContext
    {
        public LoginSenhaContext(DbContextOptions<LoginSenhaContext> option)
            : base(option) { }

        #region "DBSets"

        public DbSet<User> Users { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());

            modelBuilder.ApplyGlobalConfigurations();
            modelBuilder.SeedData();

            base.OnModelCreating(modelBuilder);
        }
    }
}
