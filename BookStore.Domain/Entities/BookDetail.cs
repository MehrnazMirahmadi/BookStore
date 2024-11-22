

using System.ComponentModel.DataAnnotations;

namespace BookStore.Domain.Entities
{
    public class BookDetail
    {
        
        public int BookDetailId { get; set; }
        public int NumberOfChapters { get; set; }
        public int NumberOfPages { get; set; }
        public double Weight { get; set; }

        public Book Book { get; set; }
    }
}
