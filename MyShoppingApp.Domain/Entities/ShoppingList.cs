using System;

namespace MyShoppingApp.Domain.Entities;

public class ShoppingList
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public Guid StoreId { get; set; }
    public Guid? GroupId { get; set; }
    public bool IsArchived { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
} 