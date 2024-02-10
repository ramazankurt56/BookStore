namespace BookStoreServer.WebApi.DTOs
{
    public class ShopListDto
    {
        public int Id { get; set; }
        public string Author { get; set; } = string.Empty;
        public string CoverImageUrl { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public decimal Price { get; set; } = 0;
        public string Publisher { get; set; } = string.Empty;
        public int Quantity { get; set; } = 0;
        public string Summary { get; set; } = string.Empty;
    }
}
