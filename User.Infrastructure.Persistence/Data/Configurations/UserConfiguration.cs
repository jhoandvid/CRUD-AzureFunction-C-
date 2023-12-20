using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users.Domain.Model;

namespace User.Infrastructure.Persistence.Data.Configurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<UserModel>
    {
        public void Configure(EntityTypeBuilder<UserModel> entity)
        {
            entity.ToTable("User");

            entity.HasKey(e=>e.Id);
            
            entity.Property(e => e.Id)
                .HasColumnName("id");

            entity.Property(e => e.BirthDay)
                .HasColumnType("datetime")
                .HasColumnName("birthDay");

            entity.Property(e => e.Document)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("document");

            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("lastName");

            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");

        }
    }
}
