namespace BookStoreServer.WebApi.DTOs
{
    public sealed record AddShoppingCartsDto(int BookId,int UserId, int Quantity);
}
