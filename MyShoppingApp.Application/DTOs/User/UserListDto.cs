namespace MyShoppingApp.Application.DTOs.User;

public class UserListDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
} 