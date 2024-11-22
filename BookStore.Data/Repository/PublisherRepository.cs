using BookStore.Data.Context;
using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces;

namespace BookStore.Data.Repository
{
    public class PublisherRepository : IPublisherRepository
    {
        #region DbContext
        private readonly BookStoreDbContext _dbContext;
        public PublisherRepository(BookStoreDbContext storeDbContext)
        {
                _dbContext = storeDbContext;
        }
        #endregion
        public IQueryable<Publisher> GetAllPublisher()
        {
            return _dbContext.publishers.AsQueryable();
        }
    }
}
