using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using MyShoppingApp.Application.DTOs.User;
using MyShoppingApp.Application.Interfaces;
using MyShoppingApp.WebApp.Components.Core;

namespace MyShoppingApp.WebApp.Users;

public class UserCreateViewModel : ViewModelBase
{
    private readonly IUserService _userService;

    [Required]
    public string Name { get; set; } = string.Empty;
    [Required, EmailAddress]
    public string Email { get; set; } = string.Empty;

    public bool IsSuccess { get; set; }

    public UserCreateViewModel(IUserService userService)
    {
        _userService = userService;
    }

    public async Task CreateAsync()
    {
        IsBusy = true;
        try
        {
            var dto = new UserCreateDto { Name = Name, Email = Email };
            await _userService.RegisterAsync(dto);
            IsSuccess = true;
            Name = Email = string.Empty;
        }
        catch (Exception ex)
        {
            ErrorMessage = $"Failed to create user: {ex.Message}";
        }
        finally
        {
            IsBusy = false;
        }
    }
} 