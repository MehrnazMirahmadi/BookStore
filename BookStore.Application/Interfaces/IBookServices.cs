using BookStore.Domain.Entities;
using BookStore.Domain.ViewModels.AuthorVM;
using BookStore.Domain.ViewModels.BookVM;
using BookStore.Domain.ViewModels.CategoryVM;
using BookStore.Domain.ViewModels.PublisherVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.Interfaces
{
    public interface IBookServices
    {
        Task<BookSearchModel> GetSearch(BookSearchModel searchModel);
        Task<List<Book>> GetLatestBooks();

        Task<List<CategoryViewModel>> GetCategories();
        Task<List<PublisherViewModel>> GetPublisher();
        Task<List<AuthorViewModel>> GetAuthors();
        Task CreateBook(AddBookViewModel bookview);
      
    }
}
