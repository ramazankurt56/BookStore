using BookStoreServer.WebApi.Context;
using BookStoreServer.WebApi.DTOs;
using BookStoreServer.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace BookStoreServer.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly AppDbContext _context;
        public BooksController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetById(int Id)
        {
            if (Id!=null)
            {
                Book? books = _context.Books.Where(p => p.Id == Id).FirstOrDefault();
                if (books!=null)
                {
                    return Ok(books);
                }
                else { 
                    var bookIndex = _context.Books.Where(p => p.Id == 2).FirstOrDefault();
                    return Ok(bookIndex);
                }
            }
            else
            {
                Book? books = _context.Books.Where(p => p.Id == 2).FirstOrDefault();           
                    return Ok(books);
            }
          
            
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Book> books = _context.Books.ToList();
            List<BookDto> requestDto = new();
            foreach (Book book in books)
            {
                BookDto bookDto =new BookDto()
                {
                    Id = book.Id,
                    Author = book.Author,
                    CoverImageUrl = book.CoverImageUrl,
                    Description = book.Description,
                    Dimensions = book.Dimensions,
                    Title = book.Title,
                    Format = book.Format,
                    Language = book.Language,
                    Price = book.Price,
                    PublicationDate = book.PublicationDate,
                    Publisher   = book.Publisher,
                    Quantity = book.Quantity,
                    Summary = book.Summary,
                };
                requestDto.Add(bookDto);
            }
            return Ok(requestDto);   
        }
    }
}
