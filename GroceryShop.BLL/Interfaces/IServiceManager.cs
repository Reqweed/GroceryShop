using GroceryShop.BLL.Auth.Interfaces;

namespace GroceryShop.BLL.Interfaces;

public interface IServiceManager
{
    IAuthenticationService Authentication { get; }
    IAuthorisationService Authorisation { get; }
    ICartService Cart { get; }
    ICategoryService Category { get; }
    IOrderService Order { get; }
    IProductService Product { get; }
    ISupplierService Supplier { get; }
    IUserService User { get; }
}