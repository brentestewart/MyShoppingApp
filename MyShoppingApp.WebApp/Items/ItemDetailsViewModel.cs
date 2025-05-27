using System.Threading.Tasks;
using MyShoppingApp.Application.DTOs.Item;
using MyShoppingApp.Application.Interfaces;
using MyShoppingApp.WebApp.Components.Core;

namespace MyShoppingApp.WebApp.Items;

public class ItemDetailsViewModel : ViewModelBase
{
    private readonly IItemService _itemService;
    public ItemReadDto? Item { get; private set; }

    public ItemDetailsViewModel(IItemService itemService)
    {
        _itemService = itemService;
    }

    public async Task LoadAsync(Guid id)
    {
        try
        {
            Item = await _itemService.GetByIdAsync(id);
        }
        catch (Exception ex)
        {
            ErrorMessage = $"Failed to load item: {ex.Message}";
        }
    }
} 