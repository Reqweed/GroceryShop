using AutoMapper;
using GroceryShop.BLL.Interfaces;
using GroceryShop.DAL.Entities.DataTransferObjects.SupplierDto;
using GroceryShop.DAL.Entities.Exceptions.BadRequestException;
using GroceryShop.DAL.Entities.Exceptions.NotFoundException;
using GroceryShop.DAL.Entities.Models;
using GroceryShop.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GroceryShop.BLL.Services;

public class SupplierService : ISupplierService
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly IMapper _mapper;
    
    public SupplierService(IMapper mapper, IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
        _mapper = mapper;
    }

    public async Task<IEnumerable<SupplierDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        var suppliers = await _repositoryManager.Supplier.GetAll().ToListAsync(cancellationToken) 
                         ?? throw new SupplierNotFoundException();
        
        var suppliersDto = _mapper.Map<IEnumerable<Supplier>, IEnumerable<SupplierDto>>(suppliers);
        
        return suppliersDto;
    }

    public async Task<SupplierDto> GetAsync(Guid idSupplier, CancellationToken cancellationToken)
    {
        var supplier = await _repositoryManager.Supplier.GetAsync(idSupplier, cancellationToken) 
                        ?? throw new SupplierNotFoundException(idSupplier);
        
        var supplierDto = _mapper.Map<Supplier, SupplierDto>(supplier);
        
        return supplierDto;
    }

    public async Task CreateAsync(SupplierForCreatingDto supplierDto)
    {
        if (supplierDto is null)
            throw new NullDtoBadRequestException();
        
        var supplier = _mapper.Map<SupplierForCreatingDto, Supplier>(supplierDto);
        
        _repositoryManager.Supplier.Create(supplier);
        _repositoryManager.Save();
    }

    public async Task DeleteAsync(Guid idSupplier, CancellationToken cancellationToken)
    {
        var supplier = await _repositoryManager.Supplier.GetAsync(idSupplier, cancellationToken) 
                       ?? throw new SupplierNotFoundException(idSupplier);

        var products = _repositoryManager.Product.GetAll()
            .Where(product => product.SupplierId == supplier.Id).ToListAsync(cancellationToken);
        
        foreach (var product in await products)
        {
            product.SupplierId = null;
            _repositoryManager.Product.Update(product);
        }
        
        _repositoryManager.Supplier.Delete(supplier);
        _repositoryManager.Save();
    }

    public async Task UpdateAsync(Guid idSupplier, SupplierForUpdatingDto supplierDto)
    {
        if (supplierDto is null)
            throw new NullDtoBadRequestException();
        
        var supplier = await _repositoryManager.Supplier.GetAsync(idSupplier)
                       ?? throw new SupplierNotFoundException(idSupplier);

        if(supplierDto.Name is not null) supplier.Name = supplierDto.Name;
        if(supplierDto.ContactNumber is not null) supplier.ContactNumber = supplierDto.ContactNumber;

        _repositoryManager.Supplier.Update(supplier);
        _repositoryManager.Save();
    }
}