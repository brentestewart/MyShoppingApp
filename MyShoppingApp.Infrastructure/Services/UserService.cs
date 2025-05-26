using MyShoppingApp.Application.DTOs.User;
using MyShoppingApp.Application.Interfaces;
using Supabase;
using MyShoppingApp.Infrastructure.SupabaseModels;

namespace MyShoppingApp.Infrastructure.Services;

public class UserService : IUserService
{
    private readonly Client _supabase;

    public UserService(Client supabase)
    {
        _supabase = supabase;
    }

    public async Task<UserReadDto> RegisterAsync(UserCreateDto dto)
    {
        var dbModel = new UserDbModel
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
            Email = dto.Email
        };
        var response = await _supabase.From<UserDbModel>().Insert(dbModel);
        return ToReadDto(response.Models.First());
    }

    public async Task<UserReadDto?> GetProfileAsync(Guid id)
    {
        var response = await _supabase.From<UserDbModel>().Where(x => x.Id == id).Get();
        var model = response.Models.FirstOrDefault();
        return model != null ? ToReadDto(model) : null;
    }

    public async Task<IEnumerable<UserListDto>> GetAllAsync()
    {
        var response = await _supabase.From<UserDbModel>().Get();
        return response.Models.Select(ToListDto);
    }

    public async Task<UserReadDto> UpdateAsync(UserUpdateDto dto)
    {
        var response = await _supabase.From<UserDbModel>().Where(x => x.Id == dto.Id).Get();
        var model = response.Models.FirstOrDefault();
        if (model == null) throw new Exception("User not found");
        model.Name = dto.Name;
        model.Email = dto.Email;
        await _supabase.From<UserDbModel>().Update(model);
        return ToReadDto(model);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _supabase.From<UserDbModel>().Where(x => x.Id == id).Delete();
    }

    public Task AddToGroupAsync(Guid userId, Guid groupId, string role)
    {
        // Group membership logic would go here (likely another table)
        return Task.CompletedTask;
    }

    public Task RemoveFromGroupAsync(Guid userId, Guid groupId)
    {
        // Group membership logic would go here (likely another table)
        return Task.CompletedTask;
    }

    private static UserReadDto ToReadDto(UserDbModel model) => new()
    {
        Id = model.Id,
        Name = model.Name,
        Email = model.Email
    };

    private static UserListDto ToListDto(UserDbModel model) => new()
    {
        Id = model.Id,
        Name = model.Name,
        Email = model.Email
    };
} 