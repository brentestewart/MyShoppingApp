namespace MyShoppingApp.Application.DTOs.Item;

public class ItemCreateDto
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public Guid? GroupId { get; set; }
} 