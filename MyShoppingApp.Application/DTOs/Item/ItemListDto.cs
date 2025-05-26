namespace MyShoppingApp.Application.DTOs.Item;

public class ItemListDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public Guid? GroupId { get; set; }
} 