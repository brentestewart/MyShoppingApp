using MyShoppingApp.Application.DTOs.StoreItem;

namespace MyShoppingApp.Application.Interfaces;

public interface IStoreItemService
{
    Task<StoreItemReadDto> CreateAsync(StoreItemCreateDto dto);
    Task<StoreItemReadDto?> GetByIdAsync(Guid storeId, Guid itemId);
    Task<IEnumerable<StoreItemListDto>> GetAllAsync();
    Task<StoreItemReadDto> UpdateAsync(StoreItemUpdateDto dto);
    Task DeleteAsync(Guid storeId, Guid itemId);
} 