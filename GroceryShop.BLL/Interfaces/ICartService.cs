using GroceryShop.BLL.Entity.DataTransferObjects.OrderItemDto;

namespace GroceryShop.BLL.Interfaces;

public interface ICartService
{
    Task AddAsync(Guid idUser, OrderItemForAdditionDto orderItemDto, CancellationToken cancellationToken);
    Task RemoveAsync(Guid idUser, OrderItemForDeletionDto orderItemDto, CancellationToken cancellationToken);
    Task<IEnumerable<OrderItemDto>> GetCartAsync(Guid idUser, CancellationToken cancellationToken);
}