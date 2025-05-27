using MyShoppingApp.Application.DTOs.Store;
using MyShoppingApp.Application.Interfaces;
using MyShoppingApp.WebApp.Components.Core;

namespace MyShoppingApp.WebApp.Stores;

public class StoreDetailsViewModel : ViewModelBase
{
    private readonly IStoreService _storeService;
    private Guid _storeId;
    public StoreReadDto? Store { get; private set; }

    public StoreDetailsViewModel(IStoreService storeService)
    {
        _storeService = storeService;
    }

    public void SetStoreId(Guid storeId)
    {
        _storeId = storeId;
    }

    public override async Task OnInitializedAsync()
    {
        IsBusy = true;
        try
        {
            Store = await _storeService.GetByIdAsync(_storeId);
        }
        catch (Exception ex)
        {
            ErrorMessage = ex.Message;
        }
        finally
        {
            IsBusy = false;
        }
    }

    public async Task LoadAsync(Guid id)
    {
        IsBusy = true;
        try
        {
            Store = await _storeService.GetByIdAsync(id);
        }
        catch (Exception ex)
        {
            ErrorMessage = $"Failed to load store: {ex.Message}";
        }
        finally
        {
            IsBusy = false;
        }
    }
} 