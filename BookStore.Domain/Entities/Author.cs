namespace BookStore.Domain.Entities
{
    public class Author
    {
        public int AuthorId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string? Location { get; set; }
        public string FullName
        {
            get { return $"{FirstName} {LastName}"; }
        }


        public ICollection<BookAuthor> BookAuthors { get; set; }
    }
}
