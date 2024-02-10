using FluentValidation;

namespace BookStoreServer.WebApi.Validators
{

    public sealed class LoginValidator : AbstractValidator<LoginDto>
    {
        public LoginValidator()
        {
            RuleFor(p => p.Email).NotEmpty().WithMessage("Geçerli bir kullanıcı adı ya da mail adresi girin");
            RuleFor(p => p.Email).MinimumLength(3).WithMessage("Geçerli bir kullanıcı adı ya da mail adresi girin");
            RuleFor(p => p.Password).NotEmpty().WithMessage("Şifre alanı boş olamaz");
            RuleFor(p => p.Password).Matches("[A-Z]").WithMessage("Şife en az 1 adet büyük harf içermelidir!");
            RuleFor(p => p.Password).Matches("[a-z]").WithMessage("Şife en az 1 adet küçük harf içermelidir!");
            RuleFor(p => p.Password).Matches("[0-9]").WithMessage("Şife en az 1 adet rakam içermelidir!");
            RuleFor(p => p.Password).Matches("[^a-zA-Z0-9]").WithMessage("Şife en az 1 adet özel karakter içermelidir!");
        }
    }
}
