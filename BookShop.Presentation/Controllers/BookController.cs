using BookShop.Application.CQRS.Queries;
using BookShop.Application.CQRS.Queries.BookQueries.GetBookById;
using BookShop.Application.CQRS.Queries.BookQueries.GetBooksByDate;
using BookShop.Application.CQRS.Queries.BookQueries.GetBooksByTitle;
using Microsoft.AspNetCore.Mvc;


namespace BookShop.Presentation.Controllers
{
    [Route("book")]
    public class BookController : BaseController
    {
        /// <summary>
        /// Get the list of books
        /// </summary>
        /// <remark>
        /// Sample request:
        /// GET /books/HappyPotter
        /// </remark>
        /// <param name="title">Book Title (string)</param>
        /// <returns>Returns List of BookLookUpDto</returns>
        /// <response code="200">Success</response>
        /// <response code="204">Not Found</response>
        [HttpGet("by-title/{title}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<List<BookLookUpDto>>> GetBooksByTitle(string title)
        {
            var query = new GetBooksByTitleQuery()
            {
                Title = title
            };

            var books = await Mediator.Send(query);

            return Ok(books);
        }

        /// <summary>
        /// Get the list of books
        /// </summary>
        /// <remark>
        /// Sample request:
        /// GET /books/12-05-2005
        /// </remark>
        /// <param name="publishingDate">Book Publishing Date (DateOnly)</param>
        /// <returns>Returns List of BookLookUpDto </returns>
        /// <response code="200">Success</response>
        /// <response code="204">Not Found</response>
        [HttpGet("by-publishing-date/{publishingDate}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<List<BookLookUpDto>>> GetBooksByPublishingDate(DateOnly publishingDate)
        {
            var query = new GetBooksByDateQuery()
            {
                PublishingDate = publishingDate,
            };

            var books = await Mediator.Send(query);

            return Ok(books);
        }

        /// <summary>
        /// Get the book
        /// </summary>
        /// <remark>
        /// Sample request:
        /// GET /bookdetails/10
        /// </remark>
        /// <param name="id">Book id (int)</param>
        /// <returns>Returns BookVm</returns>
        /// <response code="200">Success</response>
        /// <response code="204">Not Found in database</response>
        [HttpGet("details/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<BookVm>> GetBookDetailsById(int id)
        {
            var query = new GetBookDetailsByIdQuery()
            {
                Id = id
            };

            var book = await Mediator.Send(query);

            return Ok(book);
        }
    }
}
