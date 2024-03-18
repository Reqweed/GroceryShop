using AutoMapper;
using GroceryShop.BLL.Entities.DataTransferObjects.ParametersDto;
using GroceryShop.BLL.Entities.DataTransferObjects.ProductDto;
using GroceryShop.BLL.Entities.Enums;
using GroceryShop.BLL.Interfaces;
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

    public async Task<ProductForCatalogDto> GetAllAsync(GetAllParametersDto parameters, CancellationToken cancellationToken)
    {
        if (parameters is null)
            throw new NullDtoBadRequestException();
        
        var products =  _repositoryManager.Product.GetAll()
                           .Where(product => product.Name.ToLower().Contains(parameters.Name.ToLower()))
                           .OrderBy(product => product.Name)
                           .Skip((parameters.PageInfo.PageNumber - 1) * parameters.PageInfo.PageSize)
                           .Take(parameters.PageInfo.PageSize);

        var productsRes = parameters.Sorting switch
        {
            TypeProductSorting.No => await products.ToListAsync(cancellationToken),
            TypeProductSorting.AscName => await products.OrderBy(product => product.Name).ToListAsync(cancellationToken),
            TypeProductSorting.DescName => await products.OrderByDescending(product => product.Name).ToListAsync(cancellationToken),
            _ => throw new BadRequestException()
        };

        var productsDto = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDto>>(productsRes);

        return new ProductForCatalogDto
        {
            Products = productsDto,
            Parameters = parameters
        };
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