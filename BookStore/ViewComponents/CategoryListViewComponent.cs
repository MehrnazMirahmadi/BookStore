using BookStore.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.ViewComponents
{
    [ViewComponent(Name = "CategoryList")]
    public class CategoryListViewComponent : ViewComponent
    {
        private readonly IBookServices _bookServices;
        public CategoryListViewComponent(IBookServices bookServices)
        {
            _bookServices = bookServices;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await _bookServices.GetCategories();
            return View(categories);
        }
    }
}
