using BookShop.Domain;
using MediatR;

namespace BookShop.Application.CQRS.Queries.OrderQueries.GetOrderById
{
    public class GetOrderByIdQuery : IRequest<OrderLookUpDto>
    {
        public int Id { get; set; }
    }
}
