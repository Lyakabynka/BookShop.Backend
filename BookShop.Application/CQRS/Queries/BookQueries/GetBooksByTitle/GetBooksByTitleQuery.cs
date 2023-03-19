using BookShop.Domain;
using MediatR;

namespace BookShop.Application.CQRS.Queries.BookQueries.GetBooksByTitle
{
    public class GetBooksByTitleQuery : IRequest<List<BookLookUpDto>>
    {
        public string Title { get; set; }
    }
}
