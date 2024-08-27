using BookStoreServer.WebApi.Context;
using BookStoreServer.WebApi.DTOs;
using BookStoreServer.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BookStoreServer.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CheckoutController : ControllerBase
    {
        private readonly AppDbContext _context;
        public CheckoutController(AppDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult AddressAdd(AddressDto request)
        {
            User? user = _context.Users.FirstOrDefault(p=>p.Id==request.UserId);
            Address? addresName = _context.Address.FirstOrDefault(p => p.UserId == request.UserId &&  p.AddressName == request.AddressName );
            if(addresName is not null)
            {
                return NoContent();
            }
            if (user is not null)
            {
                Address address = new()
                {
                    UserId = request.UserId,
                    City = request.City,
                    AddressField = request.AddressField,
                    District = request.District,
                    Email = request.Email,
                    LastName = request.LastName,
                    Name = request.LastName,
                    OrderNote = request.OrderNote,
                    PostCode = request.PostCode,
                    Telephone = request.Telephone,
                    AddressName = request.AddressName
                };
                _context.Address.Add(address);
                _context.SaveChanges();
                return Ok(address);
            }
            return NoContent();
           
        }
        [HttpGet("{userId}")]
        public IActionResult AddressGetById(int userId)
        {
            List<Address> address= _context.Address.Where(p=>p.UserId==userId).ToList();
            return Ok(address); 
        }

    }
}
