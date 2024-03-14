using AutoMapper;
using GroceryShop.BLL.Entities.DataTransferObjects.OrderItemDto;
using GroceryShop.BLL.Interfaces;
using GroceryShop.DAL.Entities.Exceptions.BadRequestException;
using GroceryShop.DAL.Entities.Exceptions.NotFoundException;
using GroceryShop.DAL.Entities.Models;
using GroceryShop.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GroceryShop.BLL.Services;

public class CartService : ICartService
{
    private readonly IMapper _mapper;
    private readonly IRepositoryManager _repositoryManager;

    public CartService(IMapper mapper, IRepositoryManager repositoryManager)
    {
        _mapper = mapper;
        _repositoryManager = repositoryManager;
    }

    public async Task AddAsync(Guid idUser, OrderItemForAdditionDto orderItemDto, CancellationToken cancellationToken)
    {
        if (orderItemDto is null)
            throw new NullDtoBadRequestException();
        
        var item = await _repositoryManager.Cart.GetAsync(idUser, orderItemDto.IdProduct, cancellationToken);
        var product = await _repositoryManager.Product.GetAsync(orderItemDto.IdProduct, cancellationToken) 
                      ?? throw new ProductNotFoundException(orderItemDto.IdProduct);
        
        if (item is null)
        {
            item = new OrderItem
            {
                Quantity = orderItemDto.Quantity,
                Price = product.Price,
                Name = product.Name,
                ProductId = product.Id,
                Product = product,
                UserId = idUser,
            };
            
            _repositoryManager.Cart.Create(item);
        }
        else
        {
            item.Quantity += orderItemDto.Quantity;
            item.Price = product.Price;
            
            _repositoryManager.Cart.Update(item);
        }
        
        _repositoryManager.Save();
    }

    public async Task RemoveAsync(Guid idUser, OrderItemForDeletionDto orderItemDto, CancellationToken cancellationToken)
    {
        if (orderItemDto is null)
            throw new NullDtoBadRequestException();
        
        var item = await _repositoryManager.Cart.GetAsync(idUser, orderItemDto.IdProduct, cancellationToken) 
                   ?? throw new CartNotFoundException(idUser, orderItemDto.IdProduct);
        var product = await _repositoryManager.Product.GetAsync(orderItemDto.IdProduct, cancellationToken) 
                      ?? throw new ProductNotFoundException(orderItemDto.IdProduct);
        
        item.Quantity -= orderItemDto.Quantity;
        item.Price = product.Price;

        if (item.Quantity < 0) 
            throw new CartNotFoundException(idUser, orderItemDto.IdProduct);
        
        if (item.Quantity == 0)
        {
            _repositoryManager.Cart.Delete(item);
        }
        else
        {
            _repositoryManager.Cart.Update(item);
        }
        
        _repositoryManager.Save();
    }

    public async Task<IEnumerable<OrderItemDto>> GetCartAsync(Guid idUser, CancellationToken cancellationToken)
    {
        var items = await _repositoryManager.Cart.GetAll(idUser).ToListAsync(cancellationToken);

        var itemsDto = _mapper.Map<IEnumerable<OrderItem>, IEnumerable<OrderItemDto>>(items);

        return itemsDto;
    }
}