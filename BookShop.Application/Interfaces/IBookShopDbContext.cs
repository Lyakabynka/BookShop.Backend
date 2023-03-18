using BookShop.Domain;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Application.Interfaces
{
    public interface IBookShopDbContext
    {
        DbSet<Book> Books { get; set; }
        DbSet<Order> Orders { get; set; }
        
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
