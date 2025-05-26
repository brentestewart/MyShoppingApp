using MyShoppingApp.Application.DTOs.Store;
using MyShoppingApp.Application.Interfaces;
using Supabase;
using MyShoppingApp.Infrastructure.SupabaseModels;

namespace MyShoppingApp.Infrastructure.Services;

public class StoreService : IStoreService
{
    private readonly Client _supabase;

    public StoreService(Client supabase)
    {
        _supabase = supabase;
    }

    public async Task<StoreReadDto> CreateAsync(StoreCreateDto dto)
    {
        // Creates a new store in Supabase
        var dbModel = new StoreDbModel
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
            Description = dto.Description,
            Address = dto.Address != null ? new AddressDbModel
            {
                Street = dto.Address.Street,
                City = dto.Address.City,
                State = dto.Address.State,
                ZipCode = dto.Address.ZipCode
            } : null,
            Website = dto.Website,
            Aisles = dto.Aisles,
            GroupId = dto.GroupId,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };
        var response = await _supabase.From<StoreDbModel>().Insert(dbModel);
        return ToReadDto(response.Models.First());
    }

    public async Task<StoreReadDto?> GetByIdAsync(Guid id)
    {
        // Gets a store by its ID
        var response = await _supabase.From<StoreDbModel>().Where(x => x.Id == id).Get();
        var model = response.Models.FirstOrDefault();
        return model != null ? ToReadDto(model) : null;
    }

    public async Task<IEnumerable<StoreListDto>> GetAllAsync()
    {
        // Gets all stores
        var response = await _supabase.From<StoreDbModel>().Get();
        return response.Models.Select(ToListDto);
    }

    public async Task<StoreReadDto> UpdateAsync(StoreUpdateDto dto)
    {
        // Updates an existing store
        var response = await _supabase.From<StoreDbModel>().Where(x => x.Id == dto.Id).Get();
        var model = response.Models.FirstOrDefault();
        if (model == null) throw new Exception("Store not found");
        model.Name = dto.Name;
        model.Description = dto.Description;
        model.Address = dto.Address != null ? new AddressDbModel
        {
            Street = dto.Address.Street,
            City = dto.Address.City,
            State = dto.Address.State,
            ZipCode = dto.Address.ZipCode
        } : null;
        model.Website = dto.Website;
        model.Aisles = dto.Aisles;
        model.GroupId = dto.GroupId;
        model.UpdatedAt = DateTime.UtcNow;
        await _supabase.From<StoreDbModel>().Update(model);
        return ToReadDto(model);
    }

    public async Task DeleteAsync(Guid id)
    {
        // Deletes a store by its ID
        await _supabase.From<StoreDbModel>().Where(x => x.Id == id).Delete();
    }

    private static StoreReadDto ToReadDto(StoreDbModel model) => new()
    {
        Id = model.Id,
        Name = model.Name,
        Description = model.Description,
        Address = model.Address != null ? new AddressDto
        {
            Street = model.Address.Street,
            City = model.Address.City,
            State = model.Address.State,
            ZipCode = model.Address.ZipCode
        } : null,
        Website = model.Website,
        Aisles = model.Aisles,
        GroupId = model.GroupId,
        CreatedAt = model.CreatedAt,
        UpdatedAt = model.UpdatedAt
    };

    private static StoreListDto ToListDto(StoreDbModel model) => new()
    {
        Id = model.Id,
        Name = model.Name,
        Description = model.Description,
        GroupId = model.GroupId
    };
} 