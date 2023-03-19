using BookShop.Domain;
using MediatR;

namespace BookShop.Application.CQRS.Queries.OrderQueries.GetOrderByDate
{
    public class GetOrdersByDateQuery : IRequest<List<OrderLookUpDto>>
    {
        public DateOnly CreatedAt { get; set; }
    }
}
