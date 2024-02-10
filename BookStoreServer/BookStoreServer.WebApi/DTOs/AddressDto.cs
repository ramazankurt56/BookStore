using BookStoreServer.WebApi.Models;

namespace BookStoreServer.WebApi.DTOs
{
    public sealed record AddressDto
    (
         int UserId ,
         string Name ,
         string LastName ,
         string City ,
         string District ,
         string AddressField ,
         string PostCode ,         
         string Telephone, 
         string Email ,
         string OrderNote ,
         string AddressName
    );
}
