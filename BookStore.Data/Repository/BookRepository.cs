using BookStore.Data.Context;
using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Data.Repository
{
    public class BookRepository : IBookRepository
    {
        #region DbContext
        private readonly BookStoreDbContext _bookStoreDbContext;
        public BookRepository(BookStoreDbContext bookStoreDbContext)
        {
            _bookStoreDbContext = bookStoreDbContext;
        }

        #endregion

        public IQueryable<Book> GetAllBooks()
        {
            return _bookStoreDbContext.books
                .Include(b => b.Category)
                .Include(b => b.Publisher)
                .Include(b => b.BookDetail)
                .Include(b=>b.OrderItems)
                .Include(b => b.BookAuthors).ThenInclude(a => a.Author);
        }

        public IQueryable<Book> GetBooksByCategoryId(int categoryId)
        {
            return _bookStoreDbContext.books
                   .Include(b => b.Category)
                   .Where(b => b.CategoryId == categoryId);

        }

        public async Task AddBook(Book book)
        {
            await _bookStoreDbContext.books.AddAsync(book);
        }

        public async Task SaveChange()
        {
            await _bookStoreDbContext.SaveChangesAsync();
        }

        public async Task AddBookDetail(BookDetail bookDetail)
        {
            await _bookStoreDbContext.bookDetails.AddAsync(bookDetail);
        }
    }
}
