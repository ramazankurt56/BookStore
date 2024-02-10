namespace BookStoreServer.WebApi.DTOs
{
    public sealed record SetShoppingCartsDto(
      int BookId,
      int UserId,
      int Quantity);
}
