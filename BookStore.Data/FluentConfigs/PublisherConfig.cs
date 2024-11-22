using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Domain.Entities;

namespace BookStore.Data.FluentConfigs
{
    public class PublisherConfig : IEntityTypeConfiguration<Publisher>
    {
        public void Configure(EntityTypeBuilder<Publisher> builder)
        {
            builder.HasKey(b => b.PublisherId);
            builder.Property(b => b.Name).IsRequired();
            builder.Property(b => b.Location).IsRequired();
            builder.Property(b => b.Name).HasMaxLength(200);
            builder.Property(b => b.Description).HasMaxLength(300);
            builder.Property(b => b.Location).HasMaxLength(200);
        }
    }

}
