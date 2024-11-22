using BookStore.Application.Interfaces;
using BookStore.Application.Services;
using BookStore.Domain.ViewModels.AuthorVM;
using BookStore.Domain.ViewModels.BookVM;
using BookStore.Domain.ViewModels.CategoryVM;
using BookStore.Domain.ViewModels.PublisherVM;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyCrm.Domain.ViewModels.Paging;
using System.Diagnostics;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBookServices _bookServices;
        public HomeController(IBookServices bookServices)
        {
            _bookServices = bookServices;
        }
        #region InflateCategories
        public async Task InflateCategories()
        {
            var cats = await _bookServices.GetCategories();
            cats.Insert(0, new CategoryViewModel
            {
                CategoryName = "...دسته بندی مورد نظر را انتخاب نمایید"
            ,
                CategoryId = -1
            });
            var Categories = new SelectList(cats, "CategoryId", "CategoryName");
            ViewBag.Categories = Categories;

        }
        #endregion
        #region InflatePublisher
        public async Task InflatePublisher()
        {
            var pubs = await _bookServices.GetPublisher();
            pubs.Insert(0, new PublisherViewModel
            {
                PublisherId = -1,
                Name = "...ناشر مورد نظر را مشخص نمایید"

            });
            var Publishers = new SelectList(pubs, "PublisherId", "Name");
            ViewBag.Publishers = Publishers;
        }
        #endregion
        #region InflateAuthors
        public async Task InflateAuthors()
        {
            var auths = await _bookServices.GetAuthors();

            auths.Insert(0, new AuthorViewModel
            {
                AuthorId = -1,
                FirstName = "...",
                LastName = "نویسنده مورد نظر را انتخاب نمایید"
            });

           
            var authors = auths.Select(a => new
            {
                a.AuthorId,
                FullName = $"{a.FirstName} {a.LastName}"
            }).ToList();

        
            ViewBag.Authors = new SelectList(authors, "AuthorId", "FullName");
        }

        #endregion
        public async Task<IActionResult> Index(BookSearchModel searchModel)
        {
            var viewModel = await _bookServices.GetSearch(searchModel);
            return View(viewModel);
        }


        public async Task<IActionResult> BookListAction(BookSearchModel sm)
        {
            return  ViewComponent("BooksList", sm);
        }
        #region Create
        //[Route("CreateBook")]
        public async Task<IActionResult> CreateBook()
        {
            await InflateCategories();
            await InflatePublisher();
            await InflateAuthors();
            return View();
        }
        [HttpPost]
        //[Route("CreateBook")]
        public async Task<IActionResult> CreateBook(AddBookViewModel addBook)
        {
            if (!ModelState.IsValid)
            {
                await InflateCategories();
                await InflatePublisher();
                await InflateAuthors();
                return View();
            }
            await _bookServices.CreateBook(addBook);
            return RedirectToAction("index");
        }
        #endregion

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
