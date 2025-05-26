using MyShoppingApp.Application.DTOs.User;

namespace MyShoppingApp.Application.Interfaces;

public interface IUserService
{
    Task<UserReadDto> RegisterAsync(UserCreateDto dto);
    Task<UserReadDto?> GetProfileAsync(Guid id);
    Task<IEnumerable<UserListDto>> GetAllAsync();
    Task<UserReadDto> UpdateAsync(UserUpdateDto dto);
    Task DeleteAsync(Guid id);
    Task AddToGroupAsync(Guid userId, Guid groupId, string role);
    Task RemoveFromGroupAsync(Guid userId, Guid groupId);
} 