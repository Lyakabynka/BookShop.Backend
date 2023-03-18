using BookShop.Application.Interfaces;
using MediatR;

namespace BookShop.Application.CQRS.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Unit>
    {
        private readonly IBookShopDbContext _context;
        public CreateOrderCommandHandler(IBookShopDbContext context) =>
            _context = context;
        public async Task<Unit> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            
        }
    }
}
