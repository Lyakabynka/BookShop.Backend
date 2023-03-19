using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookShop.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using BookShop.Application.Common.Exceptions;

namespace BookShop.Application.CQRS.Queries.BookQueries.GetBooksByDate
{
    public class GetBooksByDateQueryHandler : IRequestHandler<GetBooksByDateQuery, List<BookLookUpDto>>
    {
        private readonly IBookShopDbContext _context;
        private readonly IMapper _mapper;
        public GetBooksByDateQueryHandler(IMapper mapper, IBookShopDbContext context) =>
            (_context,_mapper) = (context,mapper);

        public async Task<List<BookLookUpDto>> Handle(GetBooksByDateQuery request, CancellationToken cancellationToken)
        {
            var books = await _context.Books
                .Where(b => b.PublishingDate == request.PublishingDate)
                .ProjectTo<BookLookUpDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            if (books == null || books.Count == 0)
            {
                throw new NotFoundException(nameof(List<BookLookUpDto>), request.PublishingDate);
            }

            return books;
        }
    }
}
