
using MediatR;

namespace BookShop.Application.CQRS.Queries.BookQueries.GetBooksByDate
{
    public class GetBooksByDateQuery : IRequest<List<BookLookUpDto>>
    {
        public DateOnly PublishingDate { get; set; }
    }
}
