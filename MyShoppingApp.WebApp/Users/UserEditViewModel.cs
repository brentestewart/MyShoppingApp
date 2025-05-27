using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using MyShoppingApp.Application.DTOs.User;
using MyShoppingApp.Application.Interfaces;
using MyShoppingApp.WebApp.Components.Core;

namespace MyShoppingApp.WebApp.Users;

public class UserEditViewModel : ViewModelBase
{
    private readonly IUserService _userService;

    [Required]
    public Guid Id { get; set; }
    [Required]
    public string Name { get; set; } = string.Empty;
    [Required, EmailAddress]
    public string Email { get; set; } = string.Empty;

    public bool IsSuccess { get; set; }

    public UserEditViewModel(IUserService userService)
    {
        _userService = userService;
    }

    public async Task LoadAsync(Guid id)
    {
        try
        {
            var user = await _userService.GetProfileAsync(id);
            if (user is not null)
            {
                Id = user.Id;
                Name = user.Name;
                Email = user.Email;
            }
            else
            {
                ErrorMessage = "User not found.";
            }
        }
        catch (Exception ex)
        {
            ErrorMessage = $"Failed to load user: {ex.Message}";
        }
    }

    public async Task UpdateAsync()
    {
        IsBusy = true;
        ErrorMessage = null;
        IsSuccess = false;
        try
        {
            var dto = new UserUpdateDto { Id = Id, Name = Name, Email = Email };
            await _userService.UpdateAsync(dto);
            IsSuccess = true;
        }
        catch (Exception ex)
        {
            ErrorMessage = $"Failed to update user: {ex.Message}";
        }
        finally
        {
            IsBusy = false;
        }
    }
} 