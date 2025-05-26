using MyShoppingApp.Application.DTOs.ShoppingList;
using MyShoppingApp.Application.Interfaces;
using Supabase;
using MyShoppingApp.Infrastructure.SupabaseModels;

namespace MyShoppingApp.Infrastructure.Services;

public class ShoppingListService : IShoppingListService
{
    private readonly Client _supabase;

    public ShoppingListService(Client supabase)
    {
        _supabase = supabase;
    }

    public async Task<ShoppingListReadDto> CreateAsync(ShoppingListCreateDto dto)
    {
        var dbModel = new ShoppingListDbModel
        {
            Id = Guid.NewGuid(),
            Title = dto.Title,
            StoreId = dto.StoreId,
            GroupId = dto.GroupId,
            IsArchived = false
        };
        var response = await _supabase.From<ShoppingListDbModel>().Insert(dbModel);
        return ToReadDto(response.Models.First());
    }

    public async Task<ShoppingListReadDto?> GetByIdAsync(Guid id)
    {
        var response = await _supabase.From<ShoppingListDbModel>().Where(x => x.Id == id).Get();
        var model = response.Models.FirstOrDefault();
        return model != null ? ToReadDto(model) : null;
    }

    public async Task<IEnumerable<ShoppingListListDto>> GetAllAsync()
    {
        var response = await _supabase.From<ShoppingListDbModel>().Get();
        return response.Models.Select(ToListDto);
    }

    public async Task<ShoppingListReadDto> UpdateAsync(ShoppingListUpdateDto dto)
    {
        var response = await _supabase.From<ShoppingListDbModel>().Where(x => x.Id == dto.Id).Get();
        var model = response.Models.FirstOrDefault();
        if (model == null) throw new Exception("ShoppingList not found");
        model.Title = dto.Title;
        model.StoreId = dto.StoreId;
        model.GroupId = dto.GroupId;
        await _supabase.From<ShoppingListDbModel>().Update(model);
        return ToReadDto(model);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _supabase.From<ShoppingListDbModel>().Where(x => x.Id == id).Delete();
    }

    public async Task ArchiveAsync(Guid id)
    {
        var response = await _supabase.From<ShoppingListDbModel>().Where(x => x.Id == id).Get();
        var model = response.Models.FirstOrDefault();
        if (model == null) throw new Exception("ShoppingList not found");
        model.IsArchived = true;
        await _supabase.From<ShoppingListDbModel>().Update(model);
    }

    public async Task UnarchiveAsync(Guid id)
    {
        var response = await _supabase.From<ShoppingListDbModel>().Where(x => x.Id == id).Get();
        var model = response.Models.FirstOrDefault();
        if (model == null) throw new Exception("ShoppingList not found");
        model.IsArchived = false;
        await _supabase.From<ShoppingListDbModel>().Update(model);
    }

    private static ShoppingListReadDto ToReadDto(ShoppingListDbModel model) => new()
    {
        Id = model.Id,
        Title = model.Title,
        StoreId = model.StoreId,
        GroupId = model.GroupId,
        IsArchived = model.IsArchived
    };

    private static ShoppingListListDto ToListDto(ShoppingListDbModel model) => new()
    {
        Id = model.Id,
        Title = model.Title,
        StoreId = model.StoreId,
        GroupId = model.GroupId,
        IsArchived = model.IsArchived
    };
} 