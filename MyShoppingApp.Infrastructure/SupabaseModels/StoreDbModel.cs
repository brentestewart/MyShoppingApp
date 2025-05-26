using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;
using System.Text.Json.Serialization;

namespace MyShoppingApp.Infrastructure.SupabaseModels;

[Table("stores")]
public class StoreDbModel : BaseModel
{
    [PrimaryKey("id")]
    public Guid Id { get; set; }

    [Column("name")]
    public string Name { get; set; } = string.Empty;

    [Column("description")]
    public string Description { get; set; } = string.Empty;

    [Column("address")]
    [JsonPropertyName("address")]
    public AddressDbModel Address { get; set; } = new AddressDbModel();

    [Column("website")]
    public string Website { get; set; } = string.Empty;

    [Column("aisles")]
    public List<string> Aisles { get; set; } = new List<string>();

    [Column("group_id")]
    public Guid? GroupId { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }
}

public class AddressDbModel
{
    [JsonPropertyName("street")]
    public string Street { get; set; } = string.Empty;
    [JsonPropertyName("city")]
    public string City { get; set; } = string.Empty;
    [JsonPropertyName("state")]
    public string State { get; set; } = string.Empty;
    [JsonPropertyName("zipCode")]
    public string ZipCode { get; set; } = string.Empty;
} 