using BookStoreServer.WebApi.Context;
using BookStoreServer.WebApi.DTOs;
using BookStoreServer.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStoreServer.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ShopListController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ShopListController(AppDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult GetAllShop(RequestDto request)
        {
            ResponseDto<List<Book>> response = new();
            List<Book> books = _context.Books.ToList();
            List<Book> newBooks = new();

            
            if (request.Filter == "default")
            {
                
                if (request.CategoryId != null)
                {
                    newBooks = _context.BookCategories
                        .Where(p => p.CategoryId == request.CategoryId)
                        .Select(s => s.Book)
                        .ToList();
                }
                else
                {
                    newBooks = books;
                }

                if (request.Author != null)
                {
                    newBooks = _context.Books.Where(s => s.Author == request.Author).ToList();
                }
                if (!string.IsNullOrEmpty(request.Search) && request.Search.Length >= 3)
                {
                    newBooks = _context.Books.Where(s => s.Title.Contains(request.Search)).ToList();
                }
            }
            else if (request.Filter == "price")
            {

                if (request.CategoryId != null)
                {
                    newBooks = _context.BookCategories
                        .Where(p => p.CategoryId == request.CategoryId)
                        .Select(s => s.Book)
                        .OrderBy(s => s.Price)
                        .ToList();
                }
                else
                {
                    newBooks = books.OrderBy(s => s.Price).ToList();
                }

                if (request.Author != null)
                {
                    newBooks = _context.Books.Where(s => s.Author == request.Author).ToList();
                }
                if (!string.IsNullOrEmpty(request.Search) && request.Search.Length >= 3)
                {
                    newBooks = _context.Books.Where(s => s.Title.Contains(request.Search)).ToList();
                }

            }
            else if (request.Filter == "price-desc")
            {

                if (request.CategoryId != null)
                {
                    newBooks = _context.BookCategories
                        .Where(p => p.CategoryId == request.CategoryId)
                        .Select(s => s.Book)
                        .OrderByDescending(s => s.Price)
                        .ToList();
                }
                else
                {
                    newBooks = books.OrderByDescending(s => s.Price).ToList();
                }

                if (request.Author != null)
                {
                    newBooks = _context.Books.Where(s => s.Author == request.Author).ToList();
                }
                if (!string.IsNullOrEmpty(request.Search) && request.Search.Length >= 3)
                {
                    newBooks = _context.Books.Where(s => s.Title.Contains(request.Search)).ToList();
                }
            }

            response.Data = newBooks
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToList();
            response.PageNumber = request.PageNumber;
            response.PageSize = request.PageSize;
            response.TotalPageCount = (int)Math.Ceiling(newBooks.Count / (double)request.PageSize);
            response.IsFirstPage = request.PageNumber == 1;
            response.IsLastPage = request.PageNumber == response.TotalPageCount;
            return Ok(response);
        }
        [HttpGet]
        public IActionResult GetAllCategory()
        {
            List<Category> categories = _context.Categories.ToList();
            return Ok(categories);
        }
        [HttpGet]
        public IActionResult GetAllAuthor()
        {
            var author = _context.Books
                             .Select(c => new { author = c.Author.Trim() })
                              .Distinct()
                             .ToList();

            return Ok(author);
        }

    }
}
