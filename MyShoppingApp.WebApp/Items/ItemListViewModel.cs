using System.Collections.Generic;
using System.Threading.Tasks;
using MyShoppingApp.Application.DTOs.Item;
using MyShoppingApp.Application.DTOs.Group;
using MyShoppingApp.Application.Interfaces;
using MyShoppingApp.WebApp.Components.Core;

namespace MyShoppingApp.WebApp.Items;

public class ItemListViewModel : ViewModelBase
{
    private readonly IItemService _itemService;
    private readonly IGroupService _groupService;
    public List<ItemListDto> Items { get; set; } = new();
    public List<GroupListDto> Groups { get; set; } = new();

    public ItemListViewModel(IItemService itemService, IGroupService groupService)
    {
        _itemService = itemService;
        _groupService = groupService;
    }

    public async Task LoadAsync()
    {
        try
        {
            Items = (await _itemService.GetAllAsync()).ToList();
            Groups = (await _groupService.GetAllAsync()).ToList();
        }
        catch (Exception ex)
        {
            ErrorMessage = $"Failed to load items: {ex.Message}";
        }
    }

    public string GetGroupName(Guid? groupId)
    {
        if (groupId == null) return string.Empty;
        var group = Groups.FirstOrDefault(g => g.Id == groupId);
        return group?.Name ?? groupId.ToString();
    }

    public async Task DeleteAsync(Guid id)
    {
        try
        {
            await _itemService.DeleteAsync(id);
            await LoadAsync();
        }
        catch (Exception ex)
        {
            ErrorMessage = $"Failed to delete item: {ex.Message}";
        }
    }
} 