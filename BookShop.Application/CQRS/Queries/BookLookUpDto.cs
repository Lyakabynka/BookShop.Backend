
using AutoMapper;
using BookShop.Application.Common.Mappings;
using BookShop.Domain;

namespace BookShop.Application.CQRS.Queries
{
    public class BookLookUpDto : IMapWith<Book>
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Book, BookLookUpDto>()
                .ForMember(bookDto => bookDto.Id,
                    option => option.MapFrom(book => book.Id))
                .ForMember(bookDto => bookDto.Title,
                    option => option.MapFrom(book => book.Title));
        }
    }
}
