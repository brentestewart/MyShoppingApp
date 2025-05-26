using MyShoppingApp.Application.DTOs.ShoppingList;

namespace MyShoppingApp.Application.Interfaces;

public interface IShoppingListService
{
    Task<ShoppingListReadDto> CreateAsync(ShoppingListCreateDto dto);
    Task<ShoppingListReadDto?> GetByIdAsync(Guid id);
    Task<IEnumerable<ShoppingListListDto>> GetAllAsync();
    Task<ShoppingListReadDto> UpdateAsync(ShoppingListUpdateDto dto);
    Task DeleteAsync(Guid id);
    Task ArchiveAsync(Guid id);
    Task UnarchiveAsync(Guid id);
} 