using AutoMapper;
using GroceryShop.BLL.Entity.DataTransferObjects.CategoryDto;
using GroceryShop.BLL.Interfaces;
using GroceryShop.DAL.Entities.Exceptions.BadRequestException;
using GroceryShop.DAL.Entities.Exceptions.NotFoundException;
using GroceryShop.DAL.Entities.Models;
using GroceryShop.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GroceryShop.BLL.Services;

public class CategoryService : ICategoryService
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly IMapper _mapper;
    
    public CategoryService(IMapper mapper, IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CategoryDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        var categories = await _repositoryManager.Category.GetAll().ToListAsync(cancellationToken) 
                         ?? throw new CategoryNotFoundException();
        
        var categoriesDto = _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDto>>(categories);
        
        return categoriesDto;
    }

    public async Task<CategoryDto> GetAsync(Guid idCategory, CancellationToken cancellationToken)
    {
        var category = await _repositoryManager.Category.GetAsync(idCategory, cancellationToken) 
                         ?? throw new CategoryNotFoundException(idCategory);
        
        var categoryDto = _mapper.Map<Category, CategoryDto>(category);
        
        return categoryDto;
    }

    public async Task CreateAsync(CategoryForCreatingDto categoryDto)
    {
        if (categoryDto is null)
            throw new NullDtoBadRequestException();
        
        var category = _mapper.Map<CategoryForCreatingDto, Category>(categoryDto);
        
        _repositoryManager.Category.Create(category);
        _repositoryManager.Save();
    }

    public async Task DeleteAsync(Guid idCategory, CancellationToken cancellationToken)
    {
        var category = await _repositoryManager.Category.GetAsync(idCategory, cancellationToken) 
                       ?? throw new CategoryNotFoundException(idCategory);

        var products = _repositoryManager.Product.GetAll()
            .Where(product => product.CategoryId == idCategory).ToListAsync(cancellationToken) 
                       ?? throw new BadRequestException();
        
        _repositoryManager.Category.Delete(category);
        _repositoryManager.Save();
    }

    public async Task UpdateAsync(Guid idCategory, CategoryForUpdatingDto categoryDto)
    {
        if (categoryDto is null)
            throw new NullDtoBadRequestException();
        
        var category = await _repositoryManager.Category.GetAsync(idCategory)
                       ?? throw new CategoryNotFoundException(idCategory);

        category.Name = categoryDto.Name;

        _repositoryManager.Category.Update(category);
        _repositoryManager.Save();
    }
}