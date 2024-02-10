namespace BookStoreServer.WebApi.DTOs
{
    public sealed class BookDto

    {
        public int Id { get; set; }
        public string Author { get; set; } = string.Empty;
        public string CoverImageUrl { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Dimensions { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Format { get; set; } = string.Empty;
        public string Language { get; set; } = string.Empty;
        public decimal Price { get; set; } = 0;
        public string PublicationDate { get; set; } = string.Empty;
        public string Publisher { get; set; } = string.Empty;
        public int Quantity { get; set; } = 0;
        public string Summary { get; set; } = string.Empty;
    }
}
