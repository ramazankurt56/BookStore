namespace BookStoreServer.WebApi.DTOs
{
    public sealed record  RequestDto(
        int PageSize,
        int PageNumber,
        string Search,
        int? CategoryId,
        string? Author,
        string Filter);
}
