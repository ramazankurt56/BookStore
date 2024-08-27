using BookStoreServer.WebApi.Context;
using BookStoreServer.WebApi.DTOs;
using BookStoreServer.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BookStoreServer.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Featured()
        {
            List<Book> books = _context.Books
        .Include(b => b.Reviews)
        .OrderByDescending(b => b.Reviews.Select(r => r.Rating).Average())
        .Take(12)
        .ToList();
            List<HomeFeaturedDto> requestDto = new();
            foreach (Book book in books)
            {
                HomeFeaturedDto homeFeaturedDto = new HomeFeaturedDto()
                {
                    Id = book.Id,
                    Author = book.Author,
                    CoverImageUrl = book.CoverImageUrl,
                    Title = book.Title,
                    Price = book.Price,
                    Publisher = book.Publisher,
                    Quantity = book.Quantity,
                    Summary = book.Summary,
                };
                requestDto.Add(homeFeaturedDto);
            }
            return Ok(requestDto);
        }
        [HttpGet]
        public IActionResult Trending()
        {
            List<Book> books = _context.Books
        .OrderByDescending(b => b.CreatedDate).Take(10) // En son ekleme tarihine göre sıralama
        .ToList();
            List<HomeFeaturedDto> requestDto = new();
            foreach (Book book in books)
            {
                HomeFeaturedDto homeFeaturedDto = new HomeFeaturedDto()
                {
                    Id = book.Id,
                    Author = book.Author,
                    CoverImageUrl = book.CoverImageUrl,
                    Title = book.Title,
                    Price = book.Price,
                    Publisher = book.Publisher,
                    Quantity = book.Quantity,
                    Summary = book.Summary,
                };
                requestDto.Add(homeFeaturedDto);
            }
            return Ok(requestDto);
        }
        [HttpGet]
        public IActionResult Selected()
        {
            List<Book> randomBooks = _context.Books.OrderBy(x => Guid.NewGuid()).Take(4).ToList();
            List<HomeFeaturedDto> requestDto = new();
            foreach (Book book in randomBooks)
            {
                HomeFeaturedDto homeFeaturedDto = new HomeFeaturedDto()
                {
                    Id = book.Id,
                    Author = book.Author,
                    CoverImageUrl = book.CoverImageUrl,
                    Title = book.Title,
                    Price = book.Price,
                    Publisher = book.Publisher,
                    Quantity = book.Quantity,
                    Summary = book.Summary,
                };
                requestDto.Add(homeFeaturedDto);
            }
            return Ok(requestDto);
        }
    }
}
