using BookStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Interfaces
{
    public interface IAuthorRepository
    {
        Task AddAuthor(Author author);
        Task AddBookAuthor(BookAuthor bookAuthor);
        Task SaveChange();
        IQueryable<Author> GetAllAuthors();
    }
}
