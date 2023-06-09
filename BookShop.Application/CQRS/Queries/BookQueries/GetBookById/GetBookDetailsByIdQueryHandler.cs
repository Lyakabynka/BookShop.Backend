﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookShop.Application.Common.Exceptions;
using BookShop.Application.Interfaces;
using BookShop.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Application.CQRS.Queries.BookQueries.GetBookById
{
    public class GetBookDetailsByIdQueryHandler : IRequestHandler<GetBookDetailsByIdQuery, BookVm>
    {
        private readonly IBookShopDbContext _context;
        private readonly IMapper _mapper;
        public GetBookDetailsByIdQueryHandler(IBookShopDbContext context, IMapper mapper) =>
            (_context,_mapper) = (context,mapper);
        public async Task<BookVm> Handle(GetBookDetailsByIdQuery request, CancellationToken cancellationToken)
        {
            var book = await _context.Books
                .FirstOrDefaultAsync(book =>
                    book.Id == request.Id,cancellationToken);

            if (book == null)
            {
                throw new NotFoundException(nameof(Book), request.Id); // return null;
            }

            var bookVm = _mapper.Map<BookVm>(book);

            return bookVm;
        }
    }
}
