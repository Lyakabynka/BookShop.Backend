using BookShop.Application.Interfaces;
using BookShop.Domain;
using BookShop.Persistence.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Persistence
{
    public class BookShopDbContext : DbContext, IBookShopDbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Author> Authors { get; set; }

        public BookShopDbContext(DbContextOptions<BookShopDbContext> options) 
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new AuthorConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}