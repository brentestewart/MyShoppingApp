namespace MyShoppingApp.Application.DTOs.ShoppingList;

public class ShoppingListCreateDto
{
    public string Title { get; set; } = string.Empty;
    public Guid StoreId { get; set; }
    public Guid? GroupId { get; set; }
} 