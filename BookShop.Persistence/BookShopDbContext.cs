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

        public BookShopDbContext(DbContextOptions<BookShopDbContext> options) 
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());

            modelBuilder.Entity<Book>()
                .Property(b => b.PublishingDate)
                .HasConversion(new DateOnlyConverter());

            modelBuilder.Entity<Order>()
                .Property(o=>o.CreationDate)
                .HasConversion(new DateOnlyConverter());

            modelBuilder.Entity<Book>()
                .HasMany(b => b.Orders)
                .WithMany(o => o.Books)
                .UsingEntity(jt=>jt.HasNoKey());


            base.OnModelCreating(modelBuilder);
        }
    }
}