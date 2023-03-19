using BookShop.Application.Interfaces;
using BookShop.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using BookShop.Application.Common.Exceptions;

namespace BookShop.Application.CQRS.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand>
    {
        private readonly IBookShopDbContext _context;
        public CreateOrderCommandHandler(IBookShopDbContext context) =>
            _context = context;

        public async Task Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            List<Book> books = new List<Book>();
            
            foreach (var itemid in request.BookIds)
            {
                books.Add((await _context.Books.FirstOrDefaultAsync(u => u.Id == itemid, cancellationToken))!);
            }

            if (books == null || books.Count != request.BookIds.Count())
            {
                throw new NotFoundException(
                    nameof(List<Book>),
                    string.Join(", ", request.BookIds));
            }

            var order = new Order()
            {
                Books = books
            };

            _context.Orders.Add(order);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
