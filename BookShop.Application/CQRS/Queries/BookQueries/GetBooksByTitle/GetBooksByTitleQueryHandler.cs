using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookShop.Application.Common.Exceptions;
using BookShop.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Application.CQRS.Queries.BookQueries.GetBooksByTitle
{
    public class GetBooksByTitleQueryHandler : IRequestHandler<GetBooksByTitleQuery, List<BookLookUpDto>>
    {
        private readonly IBookShopDbContext _context;
        private readonly IMapper _mapper;

        public GetBooksByTitleQueryHandler(IBookShopDbContext context, IMapper mapper) =>
            (_context, _mapper) = (context, mapper);

        public async Task<List<BookLookUpDto>> Handle(GetBooksByTitleQuery request, CancellationToken cancellationToken)
        {
            var books = await _context.Books
                .Where(b => b.Title.Contains(request.Title))
                .ProjectTo<BookLookUpDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            if (books == null || books.Count == 0)
            {
                throw new NotFoundException(nameof(List<BookLookUpDto>), request.Title);
            }

            return books;
        }
    }
}
