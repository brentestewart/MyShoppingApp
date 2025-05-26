namespace MyShoppingApp.Application.DTOs.StoreItem;

public class StoreItemReadDto
{
    public Guid Id { get; set; }
    public Guid StoreId { get; set; }
    public Guid ItemId { get; set; }
    public decimal? Price { get; set; }
    public string Aisle { get; set; } = string.Empty;
    public string Notes { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
} 