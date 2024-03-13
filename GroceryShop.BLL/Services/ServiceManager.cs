using AutoMapper;
using GroceryShop.BLL.Auth.Interfaces;
using GroceryShop.BLL.Auth.Services;
using GroceryShop.BLL.Interfaces;
using GroceryShop.DAL.Entities.Models;
using GroceryShop.DAL.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace GroceryShop.BLL.Services;

public class ServiceManager : IServiceManager
{
    private readonly Lazy<IAuthenticationService> _authenticationService;
    private readonly Lazy<IAuthorisationService> _authorisationService;
    private readonly Lazy<ICartService> _cartService;
    private readonly Lazy<ICategoryService> _categoryService;
    private readonly Lazy<IOrderService> _orderService;
    private readonly Lazy<IProductService> _productService;
    private readonly Lazy<ISupplierService> _supplierService;
    private readonly Lazy<IUserService> _userService;

    public ServiceManager(IRepositoryManager repositoryManager, IMapper mapper, 
        SignInManager<User> signInManager, IJwtService jwtService, RoleManager<Role> roleManager)
    {
        _authenticationService = new Lazy<IAuthenticationService>(
            () => new AuthenticationService(mapper,jwtService,signInManager));
        _authorisationService = new Lazy<IAuthorisationService>(
            () => new AuthorisationService(mapper,roleManager,signInManager));
        _cartService = new Lazy<ICartService>(
            () => new CartService(mapper, repositoryManager));
        _categoryService = new Lazy<ICategoryService>(
            () => new CategoryService(mapper, repositoryManager));
        _orderService = new Lazy<IOrderService>(
            () => new OrderService(mapper, repositoryManager));
        _productService = new Lazy<IProductService>(
            () => new ProductService(mapper, repositoryManager));
        _supplierService = new Lazy<ISupplierService>(
            () => new SupplierService(mapper, repositoryManager));
        _userService = new Lazy<IUserService>(
            () => new UserService(mapper,signInManager));
    }

    public IAuthenticationService Authentication => _authenticationService.Value;
    public IAuthorisationService Authorisation => _authorisationService.Value;
    public ICartService Cart => _cartService.Value;
    public ICategoryService Category => _categoryService.Value;
    public IOrderService Order => _orderService.Value;
    public IProductService Product => _productService.Value;
    public ISupplierService Supplier => _supplierService.Value;
    public IUserService User => _userService.Value;
}