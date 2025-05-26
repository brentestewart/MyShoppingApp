namespace MyShoppingApp.Application.DTOs.ShoppingList;

public class ShoppingListReadDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public Guid StoreId { get; set; }
    public Guid? GroupId { get; set; }
    public bool IsArchived { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
} 