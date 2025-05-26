using System;
using System.Linq;
using System.Threading.Tasks;
using MyShoppingApp.Application.DTOs.Store;
using MyShoppingApp.Application.Interfaces;
using MyShoppingApp.Web.Core.ViewModels;

namespace MyShoppingApp.Web.Stores;

public class EditStoreViewModel : ViewModelBase
{
    private readonly IStoreService _storeService;
    public StoreUpdateDto Store { get; set; } = new();
    public string AislesInput { get; set; } = string.Empty;
    public string GroupIdInput { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
    public bool IsLoading { get; set; } = true;

    public EditStoreViewModel(IStoreService storeService)
    {
        _storeService = storeService;
    }

    public async Task LoadAsync(Guid id)
    {
        try
        {
            var store = await _storeService.GetByIdAsync(id);
            if (store != null)
            {
                Store.Id = store.Id;
                Store.Name = store.Name;
                Store.Description = store.Description;
                Store.Address = store.Address;
                Store.Website = store.Website;
                Store.Aisles = store.Aisles;
                Store.GroupId = store.GroupId;
                AislesInput = string.Join(", ", store.Aisles);
                GroupIdInput = store.GroupId?.ToString() ?? string.Empty;
            }
            IsLoading = false;
        }
        catch (Exception ex)
        {
            Message = $"Error loading store: {ex.Message}";
            IsLoading = false;
        }
    }

    public async Task UpdateAsync()
    {
        Store.Aisles = AislesInput.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).ToList();
        Store.GroupId = Guid.TryParse(GroupIdInput, out var gid) ? gid : (Guid?)null;
        try
        {
            await _storeService.UpdateAsync(Store);
            Message = "Store updated successfully.";
        }
        catch (Exception ex)
        {
            Message = $"Error: {ex.Message}";
        }
    }
} 