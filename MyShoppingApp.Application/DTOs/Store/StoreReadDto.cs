namespace MyShoppingApp.Application.DTOs.Store;

public class StoreReadDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public AddressDto Address { get; set; } = new AddressDto();
    public string Website { get; set; } = string.Empty;
    public List<string> Aisles { get; set; } = new List<string>();
    public Guid? GroupId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
} 