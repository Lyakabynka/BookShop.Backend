using MediatR;

namespace BookShop.Application.CQRS.Commands.CreateOrder
{
    public class CreateOrderCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public IEnumerable<int> BookIds { get; set; }

    }
}
