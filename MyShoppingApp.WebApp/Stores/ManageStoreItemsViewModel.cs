using System.Collections.Generic;
using System.Threading.Tasks;
using MyShoppingApp.Application.DTOs.StoreItem;
using MyShoppingApp.Application.DTOs.Item;
using MyShoppingApp.Application.Interfaces;
using MyShoppingApp.WebApp.Components.Core;

namespace MyShoppingApp.WebApp.Stores;

public class ManageStoreItemsViewModel : ViewModelBase
{
    private readonly IStoreItemService _storeItemService;
    private readonly IItemService _itemService;
    public List<StoreItemListDto> StoreItems { get; set; } = new();
    public List<ItemListDto> AvailableItems { get; set; } = new();
    public string? SelectedItemId { get; set; }
    public string? Aisle { get; set; }
    public decimal? Price { get; set; }
    public Guid StoreId { get; set; }

    public ManageStoreItemsViewModel(IStoreItemService storeItemService, IItemService itemService)
    {
        _storeItemService = storeItemService;
        _itemService = itemService;
    }

    public async Task LoadAsync(Guid storeId)
    {
        Console.WriteLine($"[DEBUG] LoadAsync called with storeId={storeId}");
        IsBusy = true;
        StoreId = storeId;
        try
        {
            StoreItems = (await _storeItemService.GetAllAsync())
                .Where(si => si.StoreId == storeId).ToList();
            AvailableItems = (await _itemService.GetAllAsync()).ToList();
        }
        catch (Exception ex)
        {
            ErrorMessage = $"Failed to load store items: {ex.Message}";
        }
        finally
        {
            IsBusy = false;
        }
    }

    public async Task AddStoreItemAsync()
    {
        Console.WriteLine($"[DEBUG] AddStoreItemAsync: StoreId={StoreId}, SelectedItemId={SelectedItemId}");
        IsBusy = true;
        ErrorMessage = null;
        try
        {
            if (StoreId == Guid.Empty)
            {
                ErrorMessage = "Invalid Store. Please reload the page.";
                return;
            }
            if (string.IsNullOrEmpty(SelectedItemId))
            {
                ErrorMessage = "Please select an item.";
                return;
            }
            if (!Guid.TryParse(SelectedItemId, out var itemId))
            {
                ErrorMessage = $"Invalid item selection: {SelectedItemId}";
                return;
            }
            // Debug log
            Console.WriteLine($"[DEBUG] Creating StoreItem: StoreId={StoreId}, ItemId={itemId}, Aisle={Aisle}, Price={Price}");
            var dto = new StoreItemCreateDto
            {
                StoreId = StoreId,
                ItemId = itemId,
                Aisle = Aisle ?? string.Empty,
                Price = Price
            };
            await _storeItemService.CreateAsync(dto);
            await LoadAsync(StoreId);
            SelectedItemId = null;
            Aisle = null;
            Price = null;
        }
        catch (Exception ex)
        {
            ErrorMessage = $"Failed to add store item: {ex.Message}";
        }
        finally
        {
            IsBusy = false;
        }
    }

    public async Task DeleteStoreItemAsync(Guid storeItemId)
    {
        IsBusy = true;
        ErrorMessage = null;
        try
        {
            var storeItem = StoreItems.FirstOrDefault(si => si.Id == storeItemId);
            if (storeItem != null)
            {
                await _storeItemService.DeleteAsync(storeItem.StoreId, storeItem.ItemId);
                await LoadAsync(StoreId);
            }
        }
        catch (Exception ex)
        {
            ErrorMessage = $"Failed to delete store item: {ex.Message}";
        }
        finally
        {
            IsBusy = false;
        }
    }

    public string GetItemName(Guid itemId)
    {
        var item = AvailableItems.FirstOrDefault(i => i.Id == itemId);
        return item?.Name ?? itemId.ToString();
    }
} 