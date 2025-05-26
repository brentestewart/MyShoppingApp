using MyShoppingApp.Application.DTOs.Store;

namespace MyShoppingApp.Application.Interfaces;

public interface IStoreService
{
    Task<StoreReadDto> CreateAsync(StoreCreateDto dto);
    Task<StoreReadDto?> GetByIdAsync(Guid id);
    Task<IEnumerable<StoreListDto>> GetAllAsync();
    Task<StoreReadDto> UpdateAsync(StoreUpdateDto dto);
    Task DeleteAsync(Guid id);
} 