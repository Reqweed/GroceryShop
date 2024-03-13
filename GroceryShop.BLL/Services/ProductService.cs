using AutoMapper;
using GroceryShop.BLL.Interfaces;
using GroceryShop.DAL.Entities.DataTransferObjects.ProductDto;
using GroceryShop.DAL.Entities.Exceptions.BadRequestException;
using GroceryShop.DAL.Entities.Exceptions.NotFoundException;
using GroceryShop.DAL.Entities.Models;
using GroceryShop.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GroceryShop.BLL.Services;

public class ProductService : IProductService
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly IMapper _mapper;

    public ProductService(IMapper mapper, IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProductDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        var products = await _repositoryManager.Product.GetAll().ToListAsync(cancellationToken)
                       ?? throw new ProductNotFoundException();

        var productsDto = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDto>>(products);

        return productsDto;
    }

    public async Task<ProductDto> GetAsync(Guid idProduct, CancellationToken cancellationToken)
    {
        var product = await _repositoryManager.Product.GetAsync(idProduct, cancellationToken)
                      ?? throw new ProductNotFoundException(idProduct);

        var productDto = _mapper.Map<Product, ProductDto>(product);

        return productDto;
    }

    public async Task<ProductDto> GetWithCategoryAndSupplierAsync(Guid idProduct, CancellationToken cancellationToken)
    {
        var product = await _repositoryManager.Product.GetWithCategoryAndSupplierAsync(idProduct, cancellationToken)
                      ?? throw new ProductNotFoundException(idProduct);

        var productDto = _mapper.Map<Product, ProductDto>(product);

        return productDto;
    }

    public async Task CreateAsync(ProductForCreatingDto productDto)
    {
        if (productDto is null)
            throw new NullDtoBadRequestException();
        
        var product = _mapper.Map<ProductForCreatingDto, Product>(productDto);

        _repositoryManager.Product.Create(product);
        _repositoryManager.Save();
    }

    public async Task DeleteAsync(Guid idProduct)
    {
        var product = await _repositoryManager.Product.GetAsync(idProduct)
                      ?? throw new ProductNotFoundException(idProduct);

        _repositoryManager.Product.Delete(product);
        _repositoryManager.Save();
    }

    public async Task UpdateAsync(Guid idProduct, ProductForUpdatingDto productDto)
    {
        if (productDto is null)
            throw new NullDtoBadRequestException();
        
        var product = await _repositoryManager.Product.GetAsync(idProduct)
                      ?? throw new ProductNotFoundException(idProduct);

        if (productDto.Name is not null) product.Name = productDto.Name;
        if (productDto.Description is not null) product.Description = productDto.Description;
        if (productDto.Price is not null) product.Price = productDto.Price.Value;
        if (productDto.StockQuantity is not null) product.StockQuantity = productDto.StockQuantity.Value;
        if (productDto.CategoryId is not null) product.CategoryId = productDto.CategoryId;
        if (productDto.SupplierId is not null) product.SupplierId = productDto.SupplierId;

        _repositoryManager.Product.Update(product);
        _repositoryManager.Save();
    }
}