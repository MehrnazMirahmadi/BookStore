using BookStore.Domain.Entities;


namespace BookStore.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        IQueryable<Category> GetAllCategories();
    }
}
