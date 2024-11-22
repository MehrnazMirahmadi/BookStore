using BookStore.Domain.Entities;
using MyCrm.Domain.ViewModels.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.ViewModels.BookVM
{
 
    public class BookSearchModel : BasePaging
    {
        public List<Book> Books { get; set; } = new List<Book>();
        public string Title { get; set; }

        public BookSearchModel SetEntity(List<Book> books)
        {
            this.Books = books;
            return this;
        }

    
        public BookSearchModel SetPaging(BasePaging paging)
        {
            this.PageId = paging.PageId;
            this.AllEntitiesCount = paging.AllEntitiesCount;
            this.StartPage = paging.StartPage;
            this.EndPage = paging.EndPage;
            this.AllEntitiesCount = paging.AllEntitiesCount;
            this.SkipEntity = paging.SkipEntity;
            this.StartPage = paging.StartPage;
            this.HowManyShowPageAfterAndBefore = paging.HowManyShowPageAfterAndBefore;
            this.PageCount = paging.PageCount;
            this.TakeEntity = paging.TakeEntity;

            return this;
        }

    }

}
