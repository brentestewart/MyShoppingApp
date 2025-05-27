using System.Threading.Tasks;
using MyShoppingApp.Application.DTOs.Item;
using MyShoppingApp.Application.DTOs.Group;
using MyShoppingApp.Application.Interfaces;
using MyShoppingApp.WebApp.Components.Core;

namespace MyShoppingApp.WebApp.Items;

public class CreateItemViewModel : ViewModelBase
{
    private readonly IItemService _itemService;
    private readonly IGroupService _groupService;
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public string GroupIdInput { get; set; } = string.Empty;
    public bool IsSuccess { get; set; }
    public List<GroupListDto> Groups { get; set; } = new();

    public CreateItemViewModel(IItemService itemService, IGroupService groupService)
    {
        _itemService = itemService;
        _groupService = groupService;
    }

    public async Task CreateAsync()
    {
        IsBusy = true;
        IsSuccess = false;
        ErrorMessage = null;
        try
        {
            var dto = new ItemCreateDto
            {
                Name = Name,
                Description = Description,
                Category = Category,
                GroupId = Guid.TryParse(GroupIdInput, out var gid) ? gid : (Guid?)null
            };
            await _itemService.CreateAsync(dto);
            IsSuccess = true;
        }
        catch (Exception ex)
        {
            ErrorMessage = $"Failed to create item: {ex.Message}";
        }
        finally
        {
            IsBusy = false;
        }
    }

    public async Task LoadGroupsAsync()
    {
        Groups = (await _groupService.GetAllAsync()).ToList();
    }
} 