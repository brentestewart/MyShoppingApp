using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace MyShoppingApp.Infrastructure.SupabaseModels;

[Table("groups")]
public class GroupDbModel : BaseModel
{
    [PrimaryKey("id")]
    public Guid Id { get; set; }

    [Column("name")]
    public string Name { get; set; } = string.Empty;

    [Column("description")]
    public string Description { get; set; } = string.Empty;
} 