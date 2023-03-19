using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookShop.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using BookShop.Application.Common.Exceptions;

namespace BookShop.Application.CQRS.Queries.OrderQueries.GetOrderByDate
{
    public class GetOrdersByDateQueryHandler : IRequestHandler<GetOrdersByDateQuery, List<OrderLookUpDto>>
    {
        private readonly IBookShopDbContext _context;
        private readonly IMapper _mapper;
        public GetOrdersByDateQueryHandler(IBookShopDbContext context, IMapper mapper) =>
            (_context, _mapper) = (context, mapper);

        public async Task<List<OrderLookUpDto>> Handle(GetOrdersByDateQuery request, CancellationToken cancellationToken)
        {
            var orders = await _context.Orders
                .Where(o => o.CreationDate == request.CreatedAt)
                .ProjectTo<OrderLookUpDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            if (orders == null || orders.Count == 0)
            {
                throw new NotFoundException(nameof(List<OrderLookUpDto>), request.CreatedAt);
            }

            return orders;
        }
    }
}
