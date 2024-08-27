using BookStoreServer.WebApi.BackgroundJobs;
using BookStoreServer.WebApi.Context;
using Microsoft.EntityFrameworkCore;

public class DatabaseMigratorJob : IHostedService
{
    private readonly IServiceProvider _serviceProvider;

    public DatabaseMigratorJob(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        using var scope = _serviceProvider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        // Ensure the database is created and apply migrations
        await context.Database.EnsureCreatedAsync();
        await context.Database.MigrateAsync(cancellationToken);

        // Seed 50 fake book records
        var seedJob = new SeedJob();
        var books = seedJob.GenerateFakeBooks(50);

        if (!await context.Books.AnyAsync(cancellationToken))
        {
            await context.Books.AddRangeAsync(books, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
        }
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
