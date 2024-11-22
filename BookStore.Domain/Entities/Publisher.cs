

namespace BookStore.Domain.Entities
{
    public class Publisher
    {
        public int PublisherId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public DateTime? EstablishedDate { get; set; }
        public List<Book> Books { get; set; }
    }
}
