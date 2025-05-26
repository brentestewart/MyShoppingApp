namespace MyShoppingApp.Application.DTOs.Group;

public class GroupUpdateDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
} 