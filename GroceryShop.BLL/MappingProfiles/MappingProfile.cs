using AutoMapper;
using GroceryShop.DAL.Entities.DataTransferObjects.CategoryDto;
using GroceryShop.DAL.Entities.DataTransferObjects.OrderDto;
using GroceryShop.DAL.Entities.DataTransferObjects.OrderItemDto;
using GroceryShop.DAL.Entities.DataTransferObjects.ProductDto;
using GroceryShop.DAL.Entities.DataTransferObjects.RoleDto;
using GroceryShop.DAL.Entities.DataTransferObjects.SupplierDto;
using GroceryShop.DAL.Entities.DataTransferObjects.UserDto;
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