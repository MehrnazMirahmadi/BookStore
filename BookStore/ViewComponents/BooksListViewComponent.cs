using BookStore.Application.Interfaces;
using BookStore.Domain.ViewModels.BookVM;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.ViewComponents
{
    [ViewComponent(Name = "BooksList")]
    public class BooksListViewComponent : ViewComponent
    {
        private readonly IBookServices _bookServices;
        public BooksListViewComponent(IBookServices bookServices)
        {
                _bookServices = bookServices;
        }
        public async Task<IViewComponentResult> InvokeAsync(BookSearchModel sm)
        {
            var books = await _bookServices.GetSearch(sm);
            return View(books);
        }
    }
}
