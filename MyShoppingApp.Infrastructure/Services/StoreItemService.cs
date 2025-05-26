using MyShoppingApp.Application.DTOs.StoreItem;
using MyShoppingApp.Application.Interfaces;
using Supabase;
using MyShoppingApp.Infrastructure.SupabaseModels;

namespace MyShoppingApp.Infrastructure.Services;

public class StoreItemService : IStoreItemService
{
    private readonly Client _supabase;

    public StoreItemService(Client supabase)
    {
        _supabase = supabase;
    }

    public async Task<StoreItemReadDto> CreateAsync(StoreItemCreateDto dto)
    {
        var dbModel = new StoreItemDbModel
        {
            StoreId = dto.StoreId,
            ItemId = dto.ItemId,
            Price = dto.Price,
            Aisle = dto.Aisle,
            Notes = dto.Notes
        };
        var response = await _supabase.From<StoreItemDbModel>().Insert(dbModel);
        return ToReadDto(response.Models.First());
    }

    public async Task<StoreItemReadDto?> GetByIdAsync(Guid storeId, Guid itemId)
    {
        var response = await _supabase.From<StoreItemDbModel>().Where(x => x.StoreId == storeId && x.ItemId == itemId).Get();
        var model = response.Models.FirstOrDefault();
        return model != null ? ToReadDto(model) : null;
    }

    public async Task<IEnumerable<StoreItemListDto>> GetAllAsync()
    {
        var response = await _supabase.From<StoreItemDbModel>().Get();
        return response.Models.Select(ToListDto);
    }

    public async Task<StoreItemReadDto> UpdateAsync(StoreItemUpdateDto dto)
    {
        var response = await _supabase.From<StoreItemDbModel>().Where(x => x.StoreId == dto.StoreId && x.ItemId == dto.ItemId).Get();
        var model = response.Models.FirstOrDefault();
        if (model == null) throw new Exception("StoreItem not found");
        model.Price = dto.Price;
        model.Aisle = dto.Aisle;
        model.Notes = dto.Notes;
        await _supabase.From<StoreItemDbModel>().Update(model);
        return ToReadDto(model);
    }

    public async Task DeleteAsync(Guid storeId, Guid itemId)
    {
        await _supabase.From<StoreItemDbModel>().Where(x => x.StoreId == storeId && x.ItemId == itemId).Delete();
    }

    private static StoreItemReadDto ToReadDto(StoreItemDbModel model) => new()
    {
        StoreId = model.StoreId,
        ItemId = model.ItemId,
        Price = model.Price,
        Aisle = model.Aisle,
        Notes = model.Notes
    };

    private static StoreItemListDto ToListDto(StoreItemDbModel model) => new()
    {
        StoreId = model.StoreId,
        ItemId = model.ItemId,
        Price = model.Price,
        Aisle = model.Aisle
    };
} 