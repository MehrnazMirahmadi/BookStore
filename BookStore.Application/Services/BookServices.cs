using BookStore.Application.Interfaces;
using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces;
using BookStore.Domain.ViewModels.AuthorVM;
using BookStore.Domain.ViewModels.BookVM;
using BookStore.Domain.ViewModels.CategoryVM;
using BookStore.Domain.ViewModels.PublisherVM;
using Microsoft.EntityFrameworkCore;
using MyCrm.Domain.ViewModels.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.Services
{
    public class BookServices : IBookServices
    {
        #region IoC
        private readonly IBookRepository _bookRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IPublisherRepository _publisherRepository;
        private readonly IAuthorRepository _authorRepository;
        public BookServices(IBookRepository bookRepository
            , ICategoryRepository categoryRepository
            , IPublisherRepository publisherRepository
            , IAuthorRepository authorRepository)
        {
            _bookRepository = bookRepository;
            _categoryRepository = categoryRepository;
            _publisherRepository = publisherRepository;
            _authorRepository = authorRepository;
        }
        #endregion


        public async Task CreateBook(AddBookViewModel model)
        {
            
                    var bookDetail = new BookDetail
                    {
                        Weight = model.Weight,
                        NumberOfChapters = model.NumberOfChapters,
                        NumberOfPages = model.NumberOfPages
                    };

                    _bookRepository.AddBookDetail(bookDetail);  
                    await _bookRepository.SaveChange();  

                    var book = new Book
                    {
                        Title = model.Title,
                        ISBN = model.ISBN,
                        Price = model.Price,
                        CategoryId = model.CategoryId,
                        PublisherId = model.PublisherId,
                        BookDetailId = bookDetail.BookDetailId,  
                        PublishDate = model.PublishDate
                    };

                _bookRepository.AddBook(book);
                    await _bookRepository.SaveChange();

            if (model.SelectedAuthorIds != null && model.SelectedAuthorIds.Any())
            {
                foreach (var authorId in model.SelectedAuthorIds)
                {
                    var bookAuthor = new BookAuthor
                    {
                        BookId = book.BookId,
                        AuthorId = authorId
                    };
                    _authorRepository.AddBookAuthor(bookAuthor);
                }
                await _authorRepository.SaveChange();
            }
        }

        public async Task<List<AuthorViewModel>> GetAuthors()
        {
            var authators = await _authorRepository.GetAllAuthors().Select(authators=> new AuthorViewModel {
            
            AuthorId = authators.AuthorId,
            FirstName = authators.FirstName,
            LastName = authators.LastName,
            BirthDate = authators.BirthDate,
            Location = authators.Location
            
            
            }).ToListAsync();
            return authators;

        }

        public async Task<List<CategoryViewModel>> GetCategories()
        {
            var categories = await _categoryRepository.GetAllCategories().Select(category => new CategoryViewModel
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName,
                BookCount = category.Books.Count(),
                BestSellerBookName = category.Books
                    .OrderByDescending(book => book.OrderItems.Sum(item => item.Quantity))
                    .Select(book => book.Title)
                    .FirstOrDefault() ?? "کتابی برای این دسته موجود نیست"
            })
            .ToListAsync();

            return categories;
        }

        public async Task<List<Book>> GetLatestBooks()
        {
            var query = await _bookRepository.GetAllBooks()
                                              .OrderByDescending(x => x.PublishDate)
                                              .Take(4)
                                              .ToListAsync();
            return query;
        }

        public async Task<List<PublisherViewModel>> GetPublisher()
        {
            var publisher =await _publisherRepository.GetAllPublisher().Select(publisher => new PublisherViewModel
            {
                Name = publisher.Name,
                PublisherId = publisher.PublisherId
            })
                .ToListAsync();
            return publisher;
        }

        public async Task<BookSearchModel> GetSearch(BookSearchModel searchModel)
        {
          
            var query =  _bookRepository.GetAllBooks();

            if (!string.IsNullOrEmpty(searchModel.Title))
            {
                query = query.Where(x => x.Title.StartsWith(searchModel.Title));
            }

            #region paging

            var pager = Pager.Build(searchModel.PageId, await query.CountAsync(), searchModel.TakeEntity,
                searchModel.HowManyShowPageAfterAndBefore);

            var allEntities = await query.Paging(pager).ToListAsync();

            #endregion
            return searchModel.SetEntity(allEntities).SetPaging(pager);

       
        }
      

    }
}
