using BookShop.Application.Common.Mappings;
using BookShop.Domain;

namespace BookShop.Application.CQRS.Queries.GetBookById
{
    public class BookDetailsVm : IMapWith<Book>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Pages { get; set; }

    }
}
