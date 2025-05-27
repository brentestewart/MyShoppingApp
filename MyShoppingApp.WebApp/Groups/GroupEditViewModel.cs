using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.Collections.Generic;
using MyShoppingApp.Application.DTOs.Group;
using MyShoppingApp.Application.DTOs.User;
using MyShoppingApp.Application.Interfaces;
using MyShoppingApp.WebApp.Components.Core;

namespace MyShoppingApp.WebApp.Groups;

public class GroupEditViewModel : ViewModelBase
{
    private readonly IGroupService _groupService;
    private readonly IUserService _userService;

    [Required]
    public Guid Id { get; set; }
    [Required]
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public bool IsSuccess { get; set; }

    public List<UserListDto> AllUsers { get; set; } = new();
    public List<UserListDto> GroupMembers { get; set; } = new();
    public string? NewMemberRole { get; set; } = "member";
    private string? _newMemberUserIdString;
    public string? NewMemberUserIdString
    {
        get => _newMemberUserIdString;
        set
        {
            _newMemberUserIdString = value;
            if (Guid.TryParse(value, out var guid))
                NewMemberUserId = guid;
            else
                NewMemberUserId = null;
        }
    }
    public Guid? NewMemberUserId { get; set; }

    public GroupEditViewModel(IGroupService groupService, IUserService userService)
    {
        _groupService = groupService;
        _userService = userService;
    }

    public async Task LoadAsync(Guid id)
    {
        try
        {
            var group = await _groupService.GetByIdAsync(id);
            if (group is not null)
            {
                Id = group.Id;
                Name = group.Name;
                Description = group.Description;
            }
            else
            {
                ErrorMessage = "Group not found.";
            }
            // Load all users
            AllUsers = (await _userService.GetAllAsync()).ToList();
            // Load real group members
            GroupMembers = await _groupService.GetMembersAsync(Id);
        }
        catch (Exception ex)
        {
            ErrorMessage = $"Failed to load group: {ex.Message}";
        }
    }

    public async Task UpdateAsync()
    {
        IsBusy = true;
        ErrorMessage = null;
        IsSuccess = false;
        try
        {
            var dto = new GroupUpdateDto { Id = Id, Name = Name, Description = Description };
            await _groupService.UpdateAsync(dto);
            IsSuccess = true;
        }
        catch (Exception ex)
        {
            ErrorMessage = $"Failed to update group: {ex.Message}";
        }
        finally
        {
            IsBusy = false;
        }
    }

    public async Task AddMemberAsync()
    {
        if (NewMemberUserId is null) return;
        try
        {
            await _groupService.AddMemberAsync(Id, NewMemberUserId.Value, NewMemberRole ?? "member");
            await LoadAsync(Id);
        }
        catch (Exception ex)
        {
            ErrorMessage = $"Failed to add member: {ex.Message}";
        }
    }

    public async Task RemoveMemberAsync(Guid userId)
    {
        try
        {
            await _groupService.RemoveMemberAsync(Id, userId);
            await LoadAsync(Id);
        }
        catch (Exception ex)
        {
            ErrorMessage = $"Failed to remove member: {ex.Message}";
        }
    }
} 