using MyShoppingApp.Application.DTOs.Item;

namespace MyShoppingApp.Application.Interfaces;

public interface IItemService
{
    Task<ItemReadDto> CreateAsync(ItemCreateDto dto);
    Task<ItemReadDto?> GetByIdAsync(Guid id);
    Task<IEnumerable<ItemListDto>> GetAllAsync();
    Task<ItemReadDto> UpdateAsync(ItemUpdateDto dto);
    Task DeleteAsync(Guid id);
} 