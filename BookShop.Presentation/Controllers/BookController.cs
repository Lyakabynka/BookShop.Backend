using BookShop.Application.CQRS.Commands.CreateOrder;
using BookShop.Application.CQRS.Queries;
using BookShop.Application.CQRS.Queries.BookQueries.GetBookById;
using BookShop.Application.CQRS.Queries.BookQueries.GetBooksByDate;
using BookShop.Application.CQRS.Queries.BookQueries.GetBooksByTitle;
using BookShop.Application.CQRS.Queries.OrderQueries;
using BookShop.Application.CQRS.Queries.OrderQueries.GetOrderByDate;
using BookShop.Application.CQRS.Queries.OrderQueries.GetOrderById;
using BookShop.Application.Interfaces;
using BookShop.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Presentation.Controllers
{
    public class BookController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<List<BookLookUpDto>>> GetBooksByTitle(string title)
        {
            var query = new GetBooksByTitleQuery()
            {
                Title = title
            };

            var books = await Mediator.Send(query);

            return Ok(books);
        }

        [HttpGet]
        public async Task<ActionResult<List<BookLookUpDto>>> GetBooksByDate(DateOnly publishingDate)
        {
            var query = new GetBooksByDateQuery()
            {
                PublishingDate = publishingDate,
            };

            var books = await Mediator.Send(query);

            return Ok(books);
        }

        [HttpGet]
        public async Task<ActionResult<BookVm>> GetBookDetailsById(int id)
        {
            var query = new GetBookDetailsByIdQuery()
            {
                Id = id
            };

            var book = await Mediator.Send(query);

            return Ok(book);
        }

        [HttpGet]
        public async Task<ActionResult<OrderLookUpDto>> GetOrderById(int id)
        {
            var query = new GetOrderByIdQuery()
            {
                Id = id,
            };

            var order = await Mediator.Send(query);

            return Ok(order);
        }

        [HttpGet]
        public async Task<ActionResult<List<OrderLookUpDto>>> GetOrdersByDate(DateOnly createdAt)
        {
            var query = new GetOrdersByDateQuery()
            {
                CreatedAt = createdAt
            };

            var order = await Mediator.Send(query);

            return Ok(order);
        }

        [HttpPost]
        public async Task<ActionResult<List<BookLookUpDto>>> CreateOrder(params int[] ids)
        {
            var command = new CreateOrderCommand()
            {
                BookIds = ids
            };

            await Mediator.Send(command);

            return NoContent();
        }
    }
}
