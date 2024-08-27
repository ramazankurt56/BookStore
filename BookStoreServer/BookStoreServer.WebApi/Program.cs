using BookStoreServer.WebApi.Context;
using BookStoreServer.WebApi.Options;
using BookStoreServer.WebApi.Services;
using BookStoreServer.WebApi.Utulities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddCors(c =>
{
    c.AddDefaultPolicy(p => p.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
});
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddHostedService<DatabaseMigratorJob>();
builder.Services.TryAddScoped<JwtService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));
builder.Services.CreateServiceTool();
builder.Services.AddAuthentication().AddJwtBearer(options =>
{
    options.TokenValidationParameters = new()
    {
        ValidateIssuer = true, //tokený gönderen kiþi bilgisi
        ValidateAudience = true, //tokený kullanacak site ya da kiþi bilgisi
        ValidateIssuerSigningKey = true, //tokenýn güvenlik anahtarý üretmesini saðlayan güvenlik sözcüðü
        ValidateLifetime = true, //tokenun yaþam süresini kontrol etmek istiyor musunuz
        ValidIssuer = "Ramazan Kurt",
        ValidAudience = "Book Store Angular App",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("my secret key my secret key my secret key 1234 ... my secret key my secret key my secret key 1234 ..."))
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors();
app.UseHttpsRedirection();

app.UseAuthorization();


app.MapControllers();

app.Run();
