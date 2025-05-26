namespace MyShoppingApp.Application.DTOs.Store;

public class StoreListDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public Guid? GroupId { get; set; }
} 