using BookStoreServer.WebApi.Context;
using BookStoreServer.WebApi.DTOs;
using BookStoreServer.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreServer.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {

        AppDbContext context = new AppDbContext();
        [HttpGet]
        public IActionResult GetById(int Id)
        {
            List<Review> books = context.Reviews.Where(p => p.BookId == Id).ToList();
            return Ok(books);
        }

        [HttpPost]
        public IActionResult Add(ReviewDto request)
        {
            Review review = new Review()
            {
                BookId = request.BookId,
                Details = request.Details,
                Title = request.Title,
                Rating = request.Rating,
                CreatedDate=DateTime.Now
               
            };
            context.Reviews.Add(review);
            context.SaveChanges();
            return NoContent();
        }

    }
}
