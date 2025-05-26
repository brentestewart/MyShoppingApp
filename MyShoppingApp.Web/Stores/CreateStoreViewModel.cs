using System.Threading.Tasks;
using MyShoppingApp.Application.DTOs.Store;
using MyShoppingApp.Application.Interfaces;
using MyShoppingApp.Web.Core.ViewModels;

namespace MyShoppingApp.Web.Stores;

public class CreateStoreViewModel : ViewModelBase
{
    private readonly IStoreService _storeService;
    public StoreCreateDto Store { get; set; } = new();
    public string AislesInput { get; set; } = string.Empty;
    public string GroupIdInput { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;

    public CreateStoreViewModel(IStoreService storeService)
    {
        _storeService = storeService;
    }

    public async Task CreateAsync()
    {
        Store.Aisles = AislesInput.Split(',', System.StringSplitOptions.RemoveEmptyEntries | System.StringSplitOptions.TrimEntries).ToList();
        Store.GroupId = Guid.TryParse(GroupIdInput, out var gid) ? gid : (Guid?)null;
        try
        {
            await _storeService.CreateAsync(Store);
            Store = new();
            AislesInput = string.Empty;
            GroupIdInput = string.Empty;
            Message = "Store created successfully.";
        }
        catch (Exception ex)
        {
            Message = $"Error: {ex.Message}";
        }
    }
} 