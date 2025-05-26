using MyShoppingApp.Application.DTOs.Group;
using MyShoppingApp.Application.Interfaces;
using Supabase;
using MyShoppingApp.Infrastructure.SupabaseModels;

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

    public Task AddMemberAsync(Guid groupId, Guid userId, string role)
    {
        // Membership logic would go here (likely another table)
        return Task.CompletedTask;
    }

    public Task RemoveMemberAsync(Guid groupId, Guid userId)
    {
        // Membership logic would go here (likely another table)
        return Task.CompletedTask;
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