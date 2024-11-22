using BookStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Interfaces
{
    public interface IBookRepository
    {
        IQueryable<Book> GetAllBooks();
        IQueryable<Book> GetBooksByCategoryId(int categoryId);
        Task AddBook(Book book);
        Task AddBookDetail(BookDetail bookDetail);
        Task SaveChange();
    }
}
