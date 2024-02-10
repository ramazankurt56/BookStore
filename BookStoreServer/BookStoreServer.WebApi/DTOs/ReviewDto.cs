namespace BookStoreServer.WebApi.DTOs
{
    public sealed record ReviewDto(int BookId, string Title, string Details, int Rating);
}
