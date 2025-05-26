using MyShoppingApp.Application.DTOs.Store;
using MyShoppingApp.Application.Interfaces;
using MyShoppingApp.Web.Core.ViewModels;

namespace MyShoppingApp.Web.Stores;

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
} 