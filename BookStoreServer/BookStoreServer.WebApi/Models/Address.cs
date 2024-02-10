namespace BookStoreServer.WebApi.Models
{
    public class Address
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string AddressName { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string AddressField { get; set; }
        public string PostCode { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string OrderNote { get; set; }
    }
}
