using BookStoreServer.WebApi.Context;
using BookStoreServer.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStoreServer.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrdersController(AppDbContext _context) : ControllerBase
    {
        [HttpGet("{orderNumber}")]
        public IActionResult GetById(string orderNumber)
        {
            List<Order> orders = _context.Orders.Where(p => p.OrderNumber == orderNumber).Include(p => p.Book).ToList();
            return Ok(orders);
        }
        [HttpGet("{userId}")]
        public IActionResult GetAll(int userId)
        {
            List<Order> orders = _context.Orders
     .Where(p => p.UserId == userId)
     .GroupBy(p => p.OrderNumber)
     .Select(g => g.First())
     .ToList();
            return Ok(orders);
        }
    }
}
