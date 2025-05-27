using System.Collections.Generic;
using System.Threading.Tasks;
using MyShoppingApp.Application.DTOs.Group;
using MyShoppingApp.Application.Interfaces;
using MyShoppingApp.WebApp.Components.Core;

namespace MyShoppingApp.WebApp.Groups;

public class GroupListViewModel : ViewModelBase
{
    private readonly IGroupService _groupService;
    public List<GroupListDto> Groups { get; set; } = new();

    public GroupListViewModel(IGroupService groupService)
    {
        _groupService = groupService;
    }

    public async Task LoadAsync()
    {
        try
        {
            Groups = (await _groupService.GetAllAsync()).ToList();
        }
        catch (Exception ex)
        {
            ErrorMessage = $"Failed to load groups: {ex.Message}";
        }
    }

    public async Task DeleteAsync(Guid id)
    {
        try
        {
            await _groupService.DeleteAsync(id);
            await LoadAsync();
        }
        catch (Exception ex)
        {
            ErrorMessage = $"Failed to delete group: {ex.Message}";
        }
    }
} 