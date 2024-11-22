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
    public class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(b => b.BookId);
            builder.Property(b => b.ISBN)
                .IsRequired()
                .HasMaxLength(20);
            builder.Property(b => b.Title).IsRequired();
            builder.Property(b => b.Price).IsRequired();
            builder
                .HasOne(b => b.BookDetail)
                .WithOne(b => b.Book)
                .HasForeignKey<Book>("BookDetailId");
            builder
                .HasOne(b => b.Publisher)
                .WithMany(b => b.Books)
                .HasForeignKey(b => b.PublisherId);
            builder.Property(b => b.Title).HasMaxLength(300);

            

        }
    }
    
    
}
