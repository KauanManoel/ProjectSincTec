using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using LoginSenha.Domain.Entities;

namespace LoginSenha.Data.Mappings
{
    public class UserMap: IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.Id).IsRequired();

            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();

            builder.Property(x => x.Password).IsRequired().HasDefaultValue("TesteLoginSenha");
        }
    }
}
