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
    public class CategoryRepository : ICategoryRepository
    {
        #region DbContext
        private readonly BookStoreDbContext _dbContext;
        public CategoryRepository(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext; 
        }
        #endregion
        public IQueryable<Category> GetAllCategories()
        {
            return _dbContext.categories;
        }
    }
}
