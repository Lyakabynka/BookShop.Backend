using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Persistence
{
    static public class DbInitializer
    {
        public static void Initialize(BookShopDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
