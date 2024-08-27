using System.Text.RegularExpressions;

namespace BookStoreServer.WebApi.Models
{
    public sealed class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public decimal Price { get; set; } = 0;
        public int Quantity { get; set; } = 0;
        public string Summary { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Format { get; set; } = string.Empty;
        public string Dimensions { get; set; } = string.Empty;
        public string PublicationDate { get; set; } = string.Empty;
        public string Publisher { get; set; } = string.Empty;
        public string Language { get; set; } = string.Empty;
        public string CoverImageUrl { get; set; } = string.Empty;
        public bool IsDeleted { get; set; } = false;
        public bool IsActive { get; set; } = true;
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public List<Review> Reviews { get; set; }

    }
}
