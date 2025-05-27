using MyShoppingApp.Application.DTOs.Store;
using MyShoppingApp.Application.Interfaces;
using MyShoppingApp.WebApp.Components.Core;

namespace MyShoppingApp.WebApp.Stores;

public class StoreListViewModel : ViewModelBase
{
    private readonly IStoreService _storeService;
    public IEnumerable<StoreListDto> Stores { get; private set; } = new List<StoreListDto>();

    public StoreListViewModel(IStoreService storeService)
    {
        _storeService = storeService;
    }

    public override async Task OnInitializedAsync()
    {
        IsBusy = true;
        try
        {
            Stores = await _storeService.GetAllAsync();
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
} 