using MediatR;
using BookShop.Application.CQRS.Queries.BookQueries;

namespace BookShop.Application.CQRS.Queries.BookQueries.GetBookById
{
    public class GetBookByIdQuery : IRequest<BookVm>
    {
        public int Id { get; set; }
    }
}
