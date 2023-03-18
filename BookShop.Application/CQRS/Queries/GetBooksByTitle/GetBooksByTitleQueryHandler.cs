using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookShop.Application.Interfaces;
using BookShop.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Application.CQRS.Queries.GetBookByDate
{
    public class GetBooksByTitleQueryHandler : IRequestHandler<GetBooksByTitleQuery, IEnumerable<BookLookUpDto>>
    {
        private readonly IBookShopDbContext _context;
        private readonly IMapper _mapper;

        public GetBooksByTitleQueryHandler(IBookShopDbContext context, IMapper mapper) =>
            (_context,_mapper) = (context,mapper);

        public async Task<IEnumerable<BookLookUpDto>> Handle(GetBooksByTitleQuery request, CancellationToken cancellationToken)
        {
            //instead of contains may be something else
            var books = await _context.Books
                .Where(b => b.Title.Contains(request.Title))
                .ProjectTo<BookLookUpDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return books;
        }
    }
}
