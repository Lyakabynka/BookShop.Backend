using AutoMapper;
using BookShop.Application.Common.Mappings;
using BookShop.Domain;
using Microsoft.Extensions.Options;

namespace BookShop.Application.CQRS.Queries.BookQueries.GetBookById
{
    public class BookVm : IMapWith<Book>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Pages { get; set; }
        public DateOnly PublishingDate { get; set; }
        public float Price { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Book, BookVm>()
                .ForMember(bookVm => bookVm.Id, option =>
                    option.MapFrom(book => book.Id))
                .ForMember(bookVm => bookVm.Title, option =>
                    option.MapFrom(book => book.Title))
                .ForMember(bookVm => bookVm.Description, option =>
                    option.MapFrom(book => book.Description))
                .ForMember(bookVm => bookVm.Pages, option =>
                    option.MapFrom(book => book.Pages))
                .ForMember(bookVm => bookVm.PublishingDate, option =>
                    option.MapFrom(book => book.PublishingDate))
                .ForMember(bookVm => bookVm.Price, option=>
                    option.MapFrom(book => book.Price));
        }
    }
}
