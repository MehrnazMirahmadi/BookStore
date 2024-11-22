using BookStore.Data.Context;
using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Data.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly BookStoreDbContext _bookStoreDbContext;
        public AuthorRepository(BookStoreDbContext bookStoreDbContext)
        {
            _bookStoreDbContext = bookStoreDbContext;    
        }
        public async Task AddAuthor(Author author)
        {
            await _bookStoreDbContext.AddAsync(author);
        }

        public async Task AddBookAuthor(BookAuthor bookAuthor)
        {
            await _bookStoreDbContext.AddAsync(bookAuthor);
        }

        public IQueryable<Author> GetAllAuthors()
        {
            return _bookStoreDbContext.authors;
        }

        public async Task SaveChange()
        {
            await _bookStoreDbContext.SaveChangesAsync();
        }
    }
}
