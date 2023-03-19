using MediatR;

namespace BookShop.Application.CQRS.Commands.CreateOrder
{
    public class CreateOrderCommand : IRequest
    {
        public IEnumerable<int> BookIds { get; set; }
    }
}
