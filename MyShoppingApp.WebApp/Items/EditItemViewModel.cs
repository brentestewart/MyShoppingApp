using System.Threading.Tasks;
using MyShoppingApp.Application.DTOs.Item;
using MyShoppingApp.Application.DTOs.Group;
using MyShoppingApp.Application.Interfaces;
using MyShoppingApp.WebApp.Components.Core;

namespace MyShoppingApp.WebApp.Items;

public class EditItemViewModel : ViewModelBase
{
    private readonly IItemService _itemService;
    private readonly IGroupService _groupService;
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public string GroupIdInput { get; set; } = string.Empty;
    public bool IsSuccess { get; set; }
    public List<GroupListDto> Groups { get; set; } = new();

    public EditItemViewModel(IItemService itemService, IGroupService groupService)
    {
        _itemService = itemService;
        _groupService = groupService;
    }

    public async Task LoadAsync(Guid id)
    {
        try
        {
            var item = await _itemService.GetByIdAsync(id);
            if (item != null)
            {
                Id = item.Id;
                Name = item.Name;
                Description = item.Description;
                Category = item.Category;
                GroupIdInput = item.GroupId?.ToString() ?? string.Empty;
            }
        }
        catch (Exception ex)
        {
            // Handle exception
        }
    }

    public async Task UpdateAsync()
    {
        try
        {
            var dto = new ItemUpdateDto
            {
                Id = Id,
                Name = Name,
                Description = Description,
                Category = Category,
                GroupId = Guid.TryParse(GroupIdInput, out var gid) ? gid : (Guid?)null
            };
            await _itemService.UpdateAsync(dto);
            IsSuccess = true;
        }
        catch (Exception ex)
        {
            // Handle exception
        }
    }

    public async Task LoadGroupsAsync()
    {
        Groups = (await _groupService.GetAllAsync()).ToList();
    }
} 