namespace MyShoppingApp.Application.DTOs.Store;

public class StoreCreateDto
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public AddressDto Address { get; set; } = new AddressDto();
    public string Website { get; set; } = string.Empty;
    public List<string> Aisles { get; set; } = new List<string>();
    public Guid? GroupId { get; set; }
}

public class AddressDto
{
    public string Street { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public string ZipCode { get; set; } = string.Empty;
} 