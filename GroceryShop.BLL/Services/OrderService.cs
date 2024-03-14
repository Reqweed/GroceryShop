using AutoMapper;
using GroceryShop.BLL.Entities.DataTransferObjects.OrderDto;
using GroceryShop.BLL.Interfaces;
using GroceryShop.DAL.Entities.Enums;
using GroceryShop.DAL.Entities.Exceptions.BadRequestException;
using GroceryShop.DAL.Entities.Exceptions.NotFoundException;
using GroceryShop.DAL.Entities.Models;
using GroceryShop.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GroceryShop.BLL.Services;

public class OrderService : IOrderService
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly IMapper _mapper;
    
    public OrderService(IMapper mapper, IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
        _mapper = mapper;
    }

    public async Task<IEnumerable<OrderDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        var orders = await _repositoryManager.Order.GetAll().ToListAsync(cancellationToken) 
                         ?? throw new OrderNotFoundException();
        
        var ordersDto = _mapper.Map<IEnumerable<Order>, IEnumerable<OrderDto>>(orders);
        
        return ordersDto;
    }

    public async Task<IEnumerable<OrderDto>> GetAllAsync(Guid idUser)
    {
        var orders = await _repositoryManager.Order.GetAll()
                         .Where(order => order.UserId == idUser).ToListAsync();
        
        var ordersDto = _mapper.Map<IEnumerable<Order>, IEnumerable<OrderDto>>(orders);
        
        return ordersDto;
    }

    public async Task<OrderDto> GetAsync(Guid idOrder, CancellationToken cancellationToken)
    {
        var order = await _repositoryManager.Order.GetAsync(idOrder, cancellationToken) 
                       ?? throw new OrderNotFoundException(idOrder);
        
        var orderDto = _mapper.Map<Order, OrderDto>(order);
        
        return orderDto;
    }

    public async Task<OrderInfoDto> GetWithOrderItemAsync(Guid idOrder, CancellationToken cancellationToken)
    {
        var order = await _repositoryManager.Order.GetWithOrderItemAsync(idOrder, cancellationToken) 
                    ?? throw new OrderNotFoundException(idOrder);
        
        var orderDto = _mapper.Map<Order, OrderInfoDto>(order);
        
        return orderDto;
    }

    public async Task CreateAsync(Guid idUser, OrderForCreatingDto orderDto, CancellationToken cancellationToken)
    {
        if (orderDto is null)
            throw new NullDtoBadRequestException();
        
        var order = _mapper.Map<OrderForCreatingDto, Order>(orderDto);

        order.UserId = idUser;
        order.OrderStatus = OrderStatus.Waiting;
        order.OrderItems = await _repositoryManager.Cart.GetAll(order.UserId).ToListAsync(cancellationToken) 
                           ?? throw new CartNotFoundException(order.UserId);
        order.TotalPrice = order.OrderItems.Sum(item => item.Price * item.Quantity);
        
        foreach (var item in order.OrderItems)
        {
            var product = await _repositoryManager.Product.GetAsync(item.ProductId, cancellationToken) 
                          ?? throw new ProductNotFoundException(item.ProductId);
            
            product.StockQuantity -= item.Quantity;
            if (product.StockQuantity < 0) 
                throw new ProductNotFoundException(product.Id, item.Quantity - product.StockQuantity);
        }
        
        _repositoryManager.Order.Create(order);
        _repositoryManager.Save();
    }

    public async Task DeleteAsync(Guid idOrder)
    {
        var order = await _repositoryManager.Order.GetAsync(idOrder) 
                       ?? throw new OrderNotFoundException(idOrder);
        
        _repositoryManager.Order.Delete(order);
        _repositoryManager.Save();
    }

    public async Task UpdateAsync(Guid idOrder, OrderForUpdatingDto orderDto)
    {
        if (orderDto is null)
            throw new NullDtoBadRequestException();
        
        var order = await _repositoryManager.Order.GetWithOrderItemAsync(idOrder)
                       ?? throw new OrderNotFoundException(idOrder);
        
       if(orderDto.Address is not null) order.Address = orderDto.Address;
       if(orderDto.OrderStatus is not null) order.OrderStatus = orderDto.OrderStatus.Value;
       order.TotalPrice = order.OrderItems.Sum(item => item.Price * item.Quantity);

        _repositoryManager.Order.Update(order);
        _repositoryManager.Save();
    }
}