using BookShop.Domain;
using MediatR;

namespace BookShop.Application.CQRS.Queries.GetBookByDate
{
    public class GetBooksByTitleQuery : IRequest<IEnumerable<Book>>
    {
        public string Title { get; set; }
    }
}
