using AutoMapper;
using BookShop.Application.Common.Exceptions;
using BookShop.Application.Interfaces;
using BookShop.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Application.CQRS.Queries.OrderQueries.GetOrderById
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, OrderLookUpDto>
    {
        private readonly IBookShopDbContext _context;
        private readonly IMapper _mapper;
        public GetOrderByIdQueryHandler(IBookShopDbContext context, IMapper mapper) =>
            (_context,_mapper) = (context,mapper);
        public async Task<OrderLookUpDto> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var order = await _context.Orders
                .FirstOrDefaultAsync(o => o.Id == request.Id, cancellationToken);

            if (order == null)
            {
                throw new NotFoundException(nameof(Order), request.Id);
            }

            var orderDto = _mapper.Map<OrderLookUpDto>(order);

            return orderDto;
        }
    }
}
