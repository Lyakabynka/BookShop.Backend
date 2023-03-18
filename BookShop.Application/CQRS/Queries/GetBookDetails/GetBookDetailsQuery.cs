using BookShop.Domain;
using MediatR;

namespace BookShop.Application.CQRS.Queries.GetBookById
{
    public class GetBookByIdQuery : IRequest<Book>
    {
        public int Id { get; set; }
    }
}
