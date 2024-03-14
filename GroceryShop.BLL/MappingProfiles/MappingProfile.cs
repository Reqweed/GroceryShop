using AutoMapper;
using GroceryShop.BLL.Entities.DataTransferObjects.CategoryDto;
using GroceryShop.BLL.Entities.DataTransferObjects.OrderDto;
using GroceryShop.BLL.Entities.DataTransferObjects.OrderItemDto;
using GroceryShop.BLL.Entities.DataTransferObjects.ProductDto;
using GroceryShop.BLL.Entities.DataTransferObjects.RoleDto;
using GroceryShop.BLL.Entities.DataTransferObjects.SupplierDto;
using GroceryShop.BLL.Entities.DataTransferObjects.UserDto;
using GroceryShop.DAL.Entities.Models;

namespace GroceryShop.BLL.MappingProfiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Category, CategoryDto>();
        CreateMap<CategoryForCreatingDto, Category>();
        CreateProjection<CategoryForUpdatingDto, Category>();
        
        CreateMap<Order,OrderDto>();
        CreateMap<OrderForCreatingDto, Order>();
        CreateMap<OrderForUpdatingDto, Order>();
        
        CreateMap<Product,ProductDto>();
        CreateMap<ProductForCreatingDto, Product>();
        CreateMap<ProductForUpdatingDto, Product>();
        
        CreateMap<Supplier,SupplierDto>();
        CreateMap<SupplierForCreatingDto, Supplier>();
        CreateMap<SupplierForUpdatingDto, Supplier>();
        
        CreateMap<User,UserDto>();
        CreateMap<UserForRegistrationDto, User>();
        CreateMap<UserForUpdatingDto, User>();
        CreateMap<UserForRegistrationDto, User>();
        
        CreateMap<OrderItem, OrderItemDto>();
        CreateMap<Order, OrderInfoDto>();

        CreateMap<Role, RoleDto>();
        CreateMap<RoleForCreatingDto, Role>();
    }
}