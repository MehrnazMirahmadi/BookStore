namespace BookStore.Domain.Entities
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public double Price { get; set; }

        public int CategoryId { get; set; }
        public int BookDetailId { get; set; }
        public DateTime? PublishDate { get; set; }
        public BookDetail BookDetail { get; set; }


        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }
        public Category Category { get; set; }

        public ICollection<BookAuthor> BookAuthors { get; set; }
        public List<OrderItem> OrderItems { get; set; }

    }
}
