
using AutoMapper;
using BookShop.Application.Common.Mappings;
using BookShop.Domain;

namespace BookShop.Application.CQRS.Queries.OrderQueries
{
    public class OrderLookUpDto : IMapWith<Order>
    {
        public int Id { get; set; }
        public float Price { get; set; }
        public DateOnly CreatedAt { get; set; }

        public List<BookLookUpDto> BookLookUpDtos { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Order, OrderLookUpDto>()
                .ForMember(o => o.Id, options =>
                    options.MapFrom(odto => odto.Id))
                .ForMember(o => o.Price, options =>
                    options.MapFrom(odto => odto.Price))
                .ForMember(o => o.CreatedAt, options =>
                    options.MapFrom(odto => odto.CreatedAt))
                .ForMember(o=>o.BookLookUpDtos,options=>
                    options.MapFrom(odto => odto.Books));
        }
    }
}
