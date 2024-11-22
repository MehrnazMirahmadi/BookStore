using BookStore.Application.Interfaces;
using BookStore.Application.Services;
using BookStore.Data.Repository;
using BookStore.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BookStore.IoC
{
    public class DependencyContainers
    {
        public static void RegisterServices(IServiceCollection service)
        {
             service.AddTransient<IBookServices, BookServices>();
             service.AddTransient<IBookRepository,BookRepository>();
             service.AddTransient<ICategoryRepository, CategoryRepository>();
             service.AddTransient<IPublisherRepository, PublisherRepository>();
             service.AddTransient<IAuthorRepository, AuthorRepository>();
            

        }
    }
}