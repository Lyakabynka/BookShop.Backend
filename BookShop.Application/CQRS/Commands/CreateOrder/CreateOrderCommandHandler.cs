using BookShop.Application.Interfaces;
using BookShop.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using BookShop.Application.Common.Exceptions;
using System.Text.Json;

namespace BookShop.Application.CQRS.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand>
    {
        private readonly IBookShopDbContext _context;
        public CreateOrderCommandHandler(IBookShopDbContext context) =>
            _context = context;

        public async Task Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var booksDistinct = await _context.Books
                .Where(b => request.BookIds.Contains(b.Id))
                .ToListAsync(cancellationToken);

            var books = request.BookIds
                .Select(id => booksDistinct.FirstOrDefault(b=>b.Id==id)!)
                .ToList();

            Console.WriteLine(JsonSerializer.Serialize(books));

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
