using BookStore.Application.Interfaces;
using BookStore.Domain.ViewModels.BookVM;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.ViewComponents
{
    [ViewComponent(Name = "BooksLatest")]
    public class BookLatestViewComponent : ViewComponent
    {
        private readonly IBookServices _bookServices;
        public BookLatestViewComponent(IBookServices bookServices)
        {
            _bookServices = bookServices;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var books = await _bookServices.GetLatestBooks();
            return View(books);
        }
    }
}
