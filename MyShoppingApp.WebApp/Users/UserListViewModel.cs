using System.Collections.Generic;
using System.Threading.Tasks;
using MyShoppingApp.Application.DTOs.User;
using MyShoppingApp.Application.Interfaces;
using MyShoppingApp.WebApp.Components.Core;

namespace MyShoppingApp.WebApp.Users;

public class UserListViewModel : ViewModelBase
{
    private readonly IUserService _userService;
    public List<UserListDto> Users { get; set; } = new();

    public UserListViewModel(IUserService userService)
    {
        _userService = userService;
    }

    public async Task LoadAsync()
    {
        try
        {
            Users = (await _userService.GetAllAsync()).ToList();
        }
        catch (Exception ex)
        {
            ErrorMessage = $"Failed to load users: {ex.Message}";
        }
    }

    public async Task DeleteAsync(Guid id)
    {
        try
        {
            await _userService.DeleteAsync(id);
            await LoadAsync();
        }
        catch (Exception ex)
        {
            ErrorMessage = $"Failed to delete user: {ex.Message}";
        }
    }
} 