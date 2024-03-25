using BookStoreServer.WebApi.Context;
using BookStoreServer.WebApi.DTOs;
using BookStoreServer.WebApi.Models;
using BookStoreServer.WebApi.Services;
using BookStoreServer.WebApi.Validators;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreServer.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
   // [Authorize(AuthenticationSchemes = "Bearer")] //attribute
    public class AuthController(JwtService jwtService) : ControllerBase
    {
        AppDbContext context = new AppDbContext();
        [HttpPost]
        public IActionResult Login(LoginDto request)
        {
            LoginValidator validator = new LoginValidator();
            FluentValidation.Results.ValidationResult validationResult = validator.Validate(request);

            if (!validationResult.IsValid)
            {
                return StatusCode(422, validationResult.Errors.Select(s => s.ErrorMessage));
            }

            User? appUser = context.Users.FirstOrDefault(p => p.Email == request.Email);
            if (appUser is null)
            {
                return BadRequest(new { Message = "Kullanıcı bulunamadı!" });
            }

            User? result = context.Users.FirstOrDefault(p => p.Password == request.Password);

            if (result is null)
            {
                return BadRequest(new { Message = "Şifreniz yanlış" });
            }

            string token = jwtService.CreateToken(appUser, request.RememberMe);
            return Ok(new { AccessToken = token,Message="Giriş başarılı" });
        }
        [HttpPost]
        public IActionResult CreateAccount(CreateAccountDto request)
        {
            User? appUser = context.Users.FirstOrDefault(p=>p.Email == request.Email);
            
            if(appUser is null)
            {
                User? user = new()
                {
                    Email = request.Email,
                    Password = request.Password,
                    Lastname = request.LastName,
                    Name = request.Name,
                };
                context.Users.Add(user);
                context.SaveChanges();  
                return NoContent();
            }
            else
            {
                return BadRequest(new { Message = "Bu email adresi daha önce kayıt edilmiş" });
            }
        }

    }
}
