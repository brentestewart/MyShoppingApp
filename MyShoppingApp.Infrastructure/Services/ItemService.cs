using MyShoppingApp.Application.DTOs.Item;
using MyShoppingApp.Application.Interfaces;
using Supabase;
using MyShoppingApp.Infrastructure.SupabaseModels;

namespace MyShoppingApp.Infrastructure.Services;

public class ItemService : IItemService
{
    private readonly Client _supabase;

    public ItemService(Client supabase)
    {
        _supabase = supabase;
    }

    public async Task<ItemReadDto> CreateAsync(ItemCreateDto dto)
    {
        var dbModel = new ItemDbModel
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
            Description = dto.Description,
            Category = dto.Category,
            GroupId = dto.GroupId,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };
        var response = await _supabase.From<ItemDbModel>().Insert(dbModel);
        return ToReadDto(response.Models.First());
    }

    public async Task<ItemReadDto?> GetByIdAsync(Guid id)
    {
        var response = await _supabase.From<ItemDbModel>().Where(x => x.Id == id).Get();
        var model = response.Models.FirstOrDefault();
        return model != null ? ToReadDto(model) : null;
    }

    public async Task<IEnumerable<ItemListDto>> GetAllAsync()
    {
        var response = await _supabase.From<ItemDbModel>().Get();
        return response.Models.Select(ToListDto);
    }

    public async Task<ItemReadDto> UpdateAsync(ItemUpdateDto dto)
    {
        var response = await _supabase.From<ItemDbModel>().Where(x => x.Id == dto.Id).Get();
        var model = response.Models.FirstOrDefault();
        if (model == null) throw new Exception("Item not found");
        model.Name = dto.Name;
        model.Description = dto.Description;
        model.Category = dto.Category;
        model.GroupId = dto.GroupId;
        model.UpdatedAt = DateTime.UtcNow;
        await _supabase.From<ItemDbModel>().Update(model);
        return ToReadDto(model);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _supabase.From<ItemDbModel>().Where(x => x.Id == id).Delete();
    }

    private static ItemReadDto ToReadDto(ItemDbModel model) => new()
    {
        Id = model.Id,
        Name = model.Name,
        Description = model.Description,
        Category = model.Category,
        GroupId = model.GroupId,
        CreatedAt = model.CreatedAt,
        UpdatedAt = model.UpdatedAt
    };

    private static ItemListDto ToListDto(ItemDbModel model) => new()
    {
        Id = model.Id,
        Name = model.Name,
        Category = model.Category,
        GroupId = model.GroupId
    };
} 