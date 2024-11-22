using BookStore.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Data.FluentConfigs
{
    public class AuthorConfig : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(a=>a.AuthorId);
            builder.Property(a=>a.FirstName).HasMaxLength(100);
            builder.Property(a => a.LastName).HasMaxLength(200);
            builder.Property(a=>a.Location).HasMaxLength(50);
            builder.Ignore(a => a.FullName);

        }
    }

}
