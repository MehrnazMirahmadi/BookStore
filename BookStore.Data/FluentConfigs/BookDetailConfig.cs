using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BookStore.Domain.Entities;

namespace BookStore.Data.FluentConfigs
{
    public class BookDetailConfig : IEntityTypeConfiguration<BookDetail>
    {
        public void Configure(EntityTypeBuilder<BookDetail> builder)
        {
            // Set BookDetailId as the primary key and identity (auto-increment)
            builder.HasKey(bd => bd.BookDetailId);

            // Configure BookDetailId to be auto-incremented (identity)
            builder.Property(bd => bd.BookDetailId)
                   .ValueGeneratedOnAdd() 
                   .UseIdentityColumn();   

            // Configure other properties
            builder.Property(bd => bd.NumberOfChapters)
                   .IsRequired();

            builder.Property(bd => bd.NumberOfPages)
                   .IsRequired();

            builder.Property(bd => bd.Weight)
                   .IsRequired();

       
            
        }
    }
}
