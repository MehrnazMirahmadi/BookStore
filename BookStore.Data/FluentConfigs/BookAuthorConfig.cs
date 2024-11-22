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
    internal class BookAuthorConfig : IEntityTypeConfiguration<BookAuthor>
    {
        public void Configure(EntityTypeBuilder<BookAuthor> builder)
        {
            //Ralation Many to Many
            builder
                .HasKey(ba => new { ba.AuthorId, ba.BookId });
            builder
                .HasOne(b => b.Book)
                .WithMany(b => b.BookAuthors)
                .HasForeignKey(b => b.BookId);
            builder
                .HasOne(b => b.Author)
                .WithMany(b => b.BookAuthors)
                .HasForeignKey(b => b.AuthorId);
        }
    }

}
