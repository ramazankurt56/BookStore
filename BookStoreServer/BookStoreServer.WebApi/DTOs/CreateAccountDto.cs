namespace BookStoreServer.WebApi.DTOs
{
    public sealed record CreateAccountDto(
    string Email,
    string Password,
    string Name,
    string LastName);
}
