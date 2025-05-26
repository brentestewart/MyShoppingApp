using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace MyShoppingApp.Infrastructure.SupabaseModels;

[Table("shopping_lists")]
public class ShoppingListDbModel : BaseModel
{
    [PrimaryKey("id")]
    public Guid Id { get; set; }

    [Column("title")]
    public string Title { get; set; } = string.Empty;

    [Column("store_id")]
    public Guid StoreId { get; set; }

    [Column("group_id")]
    public Guid? GroupId { get; set; }

    [Column("is_archived")]
    public bool IsArchived { get; set; }
} 