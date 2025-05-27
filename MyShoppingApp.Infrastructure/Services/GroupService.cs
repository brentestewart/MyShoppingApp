using MyShoppingApp.Application.DTOs.Group;
using MyShoppingApp.Application.DTOs.User;
using MyShoppingApp.Application.Interfaces;
using Supabase;
using MyShoppingApp.Infrastructure.SupabaseModels;
using static Supabase.Postgrest.Constants.Operator;

namespace MyShoppingApp.Infrastructure.Services;

public class GroupService : IGroupService
{
    private readonly Client _supabase;

    public GroupService(Client supabase)
    {
        _supabase = supabase;
    }

    public async Task<GroupReadDto> CreateAsync(GroupCreateDto dto)
    {
        var dbModel = new GroupDbModel
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
            Description = dto.Description
        };
        var response = await _supabase.From<GroupDbModel>().Insert(dbModel);
        return ToReadDto(response.Models.First());
    }

    public async Task<GroupReadDto?> GetByIdAsync(Guid id)
    {
        var response = await _supabase.From<GroupDbModel>().Where(x => x.Id == id).Get();
        var model = response.Models.FirstOrDefault();
        return model != null ? ToReadDto(model) : null;
    }

    public async Task<IEnumerable<GroupListDto>> GetAllAsync()
    {
        var response = await _supabase.From<GroupDbModel>().Get();
        return response.Models.Select(ToListDto);
    }

    public async Task<GroupReadDto> UpdateAsync(GroupUpdateDto dto)
    {
        var response = await _supabase.From<GroupDbModel>().Where(x => x.Id == dto.Id).Get();
        var model = response.Models.FirstOrDefault();
        if (model == null) throw new Exception("Group not found");
        model.Name = dto.Name;
        model.Description = dto.Description;
        await _supabase.From<GroupDbModel>().Update(model);
        return ToReadDto(model);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _supabase.From<GroupDbModel>().Where(x => x.Id == id).Delete();
    }

    public async Task AddMemberAsync(Guid groupId, Guid userId, string role)
    {
        var member = new GroupMemberDbModel
        {
            GroupId = groupId,
            UserId = userId,
            Role = role,
            JoinedAt = DateTime.UtcNow
        };
        await _supabase.From<GroupMemberDbModel>().Insert(member);
    }

    public async Task RemoveMemberAsync(Guid groupId, Guid userId)
    {
        await _supabase.From<GroupMemberDbModel>()
            .Where(x => x.GroupId == groupId && x.UserId == userId)
            .Delete();
    }

    public async Task<List<UserListDto>> GetMembersAsync(Guid groupId)
    {
        // Get all group_members for this group
        var memberRows = await _supabase.From<GroupMemberDbModel>()
            .Where(x => x.GroupId == groupId)
            .Get();
        var userIds = memberRows.Models.Select(m => m.UserId).ToList();
        if (!userIds.Any()) return new List<UserListDto>();
        // Use Postgrest 'in' filter for user IDs
        var userRows = await _supabase.From<UserDbModel>()
            .Filter("id", In, userIds)
            .Get();
        return userRows.Models.Select(u => new UserListDto
        {
            Id = u.Id,
            Name = u.Name,
            Email = u.Email
        }).ToList();
    }

    private static GroupReadDto ToReadDto(GroupDbModel model) => new()
    {
        Id = model.Id,
        Name = model.Name,
        Description = model.Description
    };

    private static GroupListDto ToListDto(GroupDbModel model) => new()
    {
        Id = model.Id,
        Name = model.Name,
        Description = model.Description
    };
} 