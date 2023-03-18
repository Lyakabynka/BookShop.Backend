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
        public async Task<IEnumerable<Book>> GetBookByTitle(string Title)
        {
            var books = await Mediator.Send();
        }
    }
}
