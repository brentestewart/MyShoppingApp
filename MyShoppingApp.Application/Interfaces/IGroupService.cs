using MyShoppingApp.Application.DTOs.Group;
using MyShoppingApp.Application.DTOs.User;

namespace MyShoppingApp.Application.Interfaces;

public interface IGroupService
{
    Task<GroupReadDto> CreateAsync(GroupCreateDto dto);
    Task<GroupReadDto?> GetByIdAsync(Guid id);
    Task<IEnumerable<GroupListDto>> GetAllAsync();
    Task<GroupReadDto> UpdateAsync(GroupUpdateDto dto);
    Task DeleteAsync(Guid id);
    Task AddMemberAsync(Guid groupId, Guid userId, string role);
    Task RemoveMemberAsync(Guid groupId, Guid userId);
    Task<List<UserListDto>> GetMembersAsync(Guid groupId);
} 