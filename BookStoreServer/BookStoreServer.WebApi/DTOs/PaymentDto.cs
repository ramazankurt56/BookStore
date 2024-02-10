using BookStoreServer.WebApi.Models;
using Iyzipay.Model;

namespace BookStoreServer.WebApi.DTOs
{
    public sealed record PaymentDto(
    List<ShoppingCartResponeDto> Books,
    Buyer Buyer,
    Iyzipay.Model.Address ShippingAddress,
    Iyzipay.Model.Address BillingAddress,
    PaymentCard PaymentCard,
    int? UserId = null);
}
