using BookStoreServer.WebApi.Context;
using BookStoreServer.WebApi.DTOs;
using BookStoreServer.WebApi.Models;
using BookStoreServer.WebApi.Services;
using BookStoreServer.WebApi.Validators;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreServer.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
   // [Authorize(AuthenticationSchemes = "Bearer")] //attribute
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly JwtService _jwtService;
        public AuthController(AppDbContext context, JwtService jwtService)
        {
            _context = context;
            _jwtService = jwtService;
        }

        [HttpPost]
        public IActionResult Login(LoginDto request)
        {
            LoginValidator validator = new LoginValidator();
            FluentValidation.Results.ValidationResult validationResult = validator.Validate(request);

            if (!validationResult.IsValid)
            {
                return StatusCode(422, validationResult.Errors.Select(s => s.ErrorMessage));
            }

            User? appUser = _context.Users.FirstOrDefault(p => p.Email == request.Email);
            if (appUser is null)
            {
                return BadRequest(new { Message = "Kullanıcı bulunamadı!" });
            }

            User? result = _context.Users.FirstOrDefault(p => p.Password == request.Password);

            if (result is null)
            {
                return BadRequest(new { Message = "Şifreniz yanlış" });
            }

            string token = _jwtService.CreateToken(appUser, request.RememberMe);
            return Ok(new { AccessToken = token,Message="Giriş başarılı" });
        }
        [HttpPost]
        public IActionResult CreateAccount(CreateAccountDto request)
        {
            User? appUser = _context.Users.FirstOrDefault(p=>p.Email == request.Email);
            
            if(appUser is null)
            {
                User? user = new()
                {
                    Email = request.Email,
                    Password = request.Password,
                    Lastname = request.LastName,
                    Name = request.Name,
                };
                _context.Users.Add(user);
                _context.SaveChanges();  
                return NoContent();
            }
            else
            {
                return BadRequest(new { Message = "Bu email adresi daha önce kayıt edilmiş" });
            }
        }

    }
}
