namespace BookStoreServer.WebApi.Models
{
    public class Review
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public int Rating { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}
