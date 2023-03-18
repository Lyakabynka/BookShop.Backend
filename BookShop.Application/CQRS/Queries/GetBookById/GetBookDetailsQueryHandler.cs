using BookShop.Application.CQRS.Exceptions;
using BookShop.Application.Interfaces;
using BookShop.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Application.CQRS.Queries.GetBookById
{
    public class GetBookDetailsQueryHandler : IRequestHandler<GetBookDetailsQuery, Book>
    {
        private readonly IBookShopDbContext _context;
        public GetBookDetailsQueryHandler(IBookShopDbContext context) =>
            _context = context;
        public async Task<Book> Handle(GetBookDetailsQuery request, CancellationToken cancellationToken)
        {
            var book = await _context.Books
                .FirstOrDefaultAsync(book=>
                    book.Id == request.Id, cancellationToken);

            if (book == null)
            {
                throw new NotFoundException(nameof(Book),request.Id);
            }

            return 
        }
    }
}
