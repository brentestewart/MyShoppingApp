using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace MyShoppingApp.Infrastructure.SupabaseModels;

[Table("users")]
public class UserDbModel : BaseModel
{
    [PrimaryKey("id")]
    public Guid Id { get; set; }

    [Column("name")]
    public string Name { get; set; } = string.Empty;

    [Column("email")]
    public string Email { get; set; } = string.Empty;
} 