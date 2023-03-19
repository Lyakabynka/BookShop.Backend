using BookShop.Application.CQRS.Commands.CreateOrder;
using BookShop.Application.CQRS.Queries.OrderQueries.GetOrderByDate;
using BookShop.Application.CQRS.Queries.OrderQueries.GetOrderById;
using BookShop.Application.CQRS.Queries.OrderQueries;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Presentation.Controllers
{
    [Route("order")]
    public class OrderController : BaseController
    {
        /// <summary>
        /// Get the order
        /// </summary>
        /// <remark>
        /// Sample request:
        /// GET /order/10
        /// </remark>
        /// <param name="id">Order id (int)</param>
        /// <returns>Returns OrderLookUpDto</returns>
        /// <response code="200">Success</response>
        /// <response code="204">Not Found in database</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<OrderLookUpDto>> GetOrderById(int id)
        {
            var query = new GetOrderByIdQuery()
            {
                Id = id,
            };

            var order = await Mediator.Send(query);

            return Ok(order);
        }

        /// <summary>
        /// Get the orders
        /// </summary>
        /// <remark>
        /// Sample request:
        /// GET /orders/12-05-2005
        /// </remark>
        /// <param name="creationDate">Order creation date (DateOnly)</param>
        /// <returns>Returns List of OrderLookUpDto</returns>
        /// <response code="200">Success</response>
        /// <response code="204">Not Found in database</response>
        [HttpGet("by-creation-date/{creationDate}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<List<OrderLookUpDto>>> GetOrdersByCreationDate(DateOnly creationDate)
        {
            var query = new GetOrdersByDateQuery()
            {
                CreatedAt = creationDate
            };

            var order = await Mediator.Send(query);

            return Ok(order);
        }

        /// <summary>
        /// Create the order
        /// </summary>
        /// <remark>
        /// Sample request:
        /// GET /orders/
        /// {
        ///     "ids": [1,2,3,4]
        /// }
        /// </remark>
        /// <param name="id">Book ids to include into the order (List of int)</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="200">Success</response>
        [HttpPost("by-ids")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateOrderByIds([FromQuery] List<int> id)
        {
            var command = new CreateOrderCommand()
            {
                BookIds = id
            };

            await Mediator.Send(command);

            return Ok();
        }
    }
}
