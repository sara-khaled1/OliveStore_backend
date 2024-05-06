using AutoMapper;
using sda_onsite_2_csharp_backend_teamwork.src.DTO;
using sda_onsite_2_csharp_backend_teamwork.src.Entity;

namespace sda_onsite_2_csharp_backend_teamwork.src.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ProductReadDto, Product>();
        CreateMap<Product, ProductReadDto>();
        CreateMap<Product, ProductCreateDto>();
        CreateMap<ProductCreateDto, Product>();

        CreateMap<OrderReadDto, Order>();
        CreateMap<Order, OrderReadDto>();

        CreateMap<CheckoutDto, OrderItem>();

        CreateMap<UserReadDto, User>();
        CreateMap<User, UserReadDto>();

        CreateMap<OrderItemReadDto, OrderItem>();
        CreateMap<OrderItem, OrderItemReadDto>();

        CreateMap<CategoryReadDto, Category>();
        CreateMap<Category, CategoryReadDto>();

        CreateMap<AddressReadDto, Address>();
        CreateMap<Address, AddressReadDto>();

    }
}