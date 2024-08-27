using Bogus;
using BookStoreServer.WebApi.Models;
using System;

namespace BookStoreServer.WebApi.BackgroundJobs;

public class SeedJob
{
    public List<Book> GenerateFakeBooks(int numberOfBooks)
    {
        var faker = new Faker<Book>()
            .RuleFor(b => b.Id, f => f.IndexFaker + 1)
            .RuleFor(b => b.Title, f => f.Lorem.Sentence(3))
            .RuleFor(b => b.Author, f => f.Name.FullName())
            .RuleFor(b => b.Price, f => f.Random.Decimal(10, 100))
            .RuleFor(b => b.Quantity, f => f.Random.Int(1, 100))
            .RuleFor(b => b.Summary, f => f.Lorem.Paragraph(2))
            .RuleFor(b => b.Description, f => f.Lorem.Paragraphs(3))
            .RuleFor(b => b.Format, f => f.PickRandom(new[] { "Hardcover", "Paperback", "Ebook" }))
            .RuleFor(b => b.Dimensions, f => $"{f.Random.Double(5.0, 10.0):0.0} x {f.Random.Double(5.0, 10.0):0.0} x {f.Random.Double(0.5, 3.0):0.0} inches")
            .RuleFor(b => b.PublicationDate, f => f.Date.Past(10).ToUniversalTime().ToString("yyyy-MM-dd"))  // Convert to UTC
            .RuleFor(b => b.Publisher, f => f.Company.CompanyName())
            .RuleFor(b => b.Language, f => "Türkçe")
            .RuleFor(b => b.CoverImageUrl, f => $"https://picsum.photos/200/300?random={f.Random.Number(1, 1000)}")
            .RuleFor(b => b.IsDeleted, f => f.Random.Bool(0.2f))
            .RuleFor(b => b.IsActive, f => f.Random.Bool(0.9f))
            .RuleFor(b => b.CreatedDate, f => f.Date.Past(2).ToUniversalTime())  // Convert to UTC
            .RuleFor(b => b.Reviews, f => new List<Review>());

        return faker.Generate(numberOfBooks);
    }
}
