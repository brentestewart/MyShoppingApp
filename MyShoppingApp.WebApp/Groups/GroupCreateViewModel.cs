using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using MyShoppingApp.Application.DTOs.Group;
using MyShoppingApp.Application.Interfaces;
using MyShoppingApp.WebApp.Components.Core;

namespace MyShoppingApp.WebApp.Groups;

public class GroupCreateViewModel : ViewModelBase
{
    private readonly IGroupService _groupService;

    [Required]
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public bool IsSuccess { get; set; }

    public GroupCreateViewModel(IGroupService groupService)
    {
        _groupService = groupService;
    }

    public async Task CreateAsync()
    {
        IsBusy = true;
        try
        {
            var dto = new GroupCreateDto { Name = Name, Description = Description };
            await _groupService.CreateAsync(dto);
            IsSuccess = true;
            Name = Description = string.Empty;
        }
        catch (Exception ex)
        {
            ErrorMessage = $"Failed to create group: {ex.Message}";
        }
        finally
        {
            IsBusy = false;
        }
    }
} 