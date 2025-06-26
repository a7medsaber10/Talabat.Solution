using AutoMapper;
using Talabat.APIs.DTOs;
using Talabat.Core.Entities;
using Talabat.Core.Entities.Identity;
using Talabat.Core.Order_Aggregate;

namespace Talabat.APIs.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDTO>().ForMember(d => d.Brand, o => o.MapFrom(s => s.Brand.Name))
                                            .ForMember(d => d.Category, o => o.MapFrom(s => s.Category.Name))
                                            .ForMember(d => d.PictureUrl, o => o.MapFrom<ProductPictureURLResolver>());

            CreateMap<CustomerBasketDTO, CustomerBasket>().ReverseMap();
            CreateMap<BasketItemDTO, BasketItem>().ReverseMap();

            CreateMap<AddressDTO, Core.Order_Aggregate.Address>();

            CreateMap<Core.Entities.Identity.Address, AddressDTO>()
                .ForMember(d=> d.FirstName, o => o.MapFrom(s => s.FName))
                .ForMember(d => d.LastName, o => o.MapFrom(s => s.LName)).ReverseMap();

            CreateMap<Order, OrderToReturnDTO>()
                .ForMember(d => d.DeliveryMethod, o => o.MapFrom(s => s.DeliveryMethod.ShortName))
                .ForMember(d => d.DeliveryMethodCost, o => o.MapFrom(s => s.DeliveryMethod.Cost));

            CreateMap<OrderItem, OrderItemDTO>()
                .ForMember(d => d.ProductId, o => o.MapFrom(s => s.Product.ProductId))
                .ForMember(d => d.ProductName, o => o.MapFrom(s => s.Product.ProductName))
                .ForMember(d => d.ProductURL, o => o.MapFrom(s => s.Product.ProductURL))
                .ForMember(d => d.ProductURL, o => o.MapFrom<OrderItemPictureURLResolver>());
        }
    }
}
