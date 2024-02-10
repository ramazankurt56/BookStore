using BookStoreServer.WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStoreServer.WebApi.Context
{
    public class AppDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=KURT\\SQLEXPRESS;Initial Catalog=BookStoreTestDb;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<BookCategory> BookCategories { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookCategory>().HasKey(p => new { p.BookId, p.CategoryId });
            modelBuilder.Entity<Book>().Property(p => p.Price).HasColumnType("money");
            modelBuilder.Entity<Order>().Property(p => p.Price).HasColumnType("money");
            modelBuilder.Entity<Category>().HasData(
               new Category { Id = 1, Name = "Korku", IsActive = true, IsDeleted = false },
               new Category { Id = 2, Name = "Bilim Kurgu", IsActive = true, IsDeleted = false },
               new Category { Id = 3, Name = "Tarih", IsActive = true, IsDeleted = false },
               new Category { Id = 4, Name = "Edebiyat", IsActive = true, IsDeleted = false },
               new Category { Id = 5, Name = "Çocuk", IsActive = true, IsDeleted = false },
               new Category { Id = 6, Name = "Psikoloji", IsActive = true, IsDeleted = false },
               new Category { Id = 7, Name = "Din", IsActive = true, IsDeleted = false },
               new Category { Id = 8, Name = "Felsefe", IsActive = true, IsDeleted = false },
               new Category { Id = 9, Name = "Bilim", IsActive = true, IsDeleted = false },
               new Category { Id = 10, Name = "Sanat", IsActive = true, IsDeleted = false },
               new Category { Id = 11, Name = "Spor", IsActive = true, IsDeleted = false },
               new Category { Id = 12, Name = "Gezi", IsActive = true, IsDeleted = false },
               new Category { Id = 13, Name = "Dergi", IsActive = true, IsDeleted = false },
               new Category { Id = 14, Name = "Mizah", IsActive = true, IsDeleted = false },
               new Category { Id = 15, Name = "Kişisel Gelişim", IsActive = true, IsDeleted = false },
               new Category { Id = 16, Name = "Yemek", IsActive = true, IsDeleted = false },
               new Category { Id = 17, Name = "Hobi", IsActive = true, IsDeleted = false },
               new Category { Id = 18, Name = "Referans", IsActive = true, IsDeleted = false },
               new Category { Id = 19, Name = "Eğitim", IsActive = true, IsDeleted = false }
               );
        }
    }
}
