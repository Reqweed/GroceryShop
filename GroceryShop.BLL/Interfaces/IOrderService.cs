using GroceryShop.DAL.Entities.DataTransferObjects.OrderDto;

namespace GroceryShop.BLL.Interfaces;

public interface IOrderService
{
    Task<IEnumerable<OrderDto>> GetAllAsync(CancellationToken cancellationToken);
    Task<IEnumerable<OrderDto>> GetAllAsync(Guid idUser);
    Task<OrderDto> GetAsync(Guid idOrder, CancellationToken cancellationToken);
    Task<OrderInfoDto> GetWithOrderItemAsync(Guid idOrder, CancellationToken cancellationToken);
    Task CreateAsync(Guid idUser, OrderForCreatingDto orderDto, CancellationToken cancellationToken);
    Task DeleteAsync(Guid idOrder);
    Task UpdateAsync(Guid idOrder, OrderForUpdatingDto orderDto);
}