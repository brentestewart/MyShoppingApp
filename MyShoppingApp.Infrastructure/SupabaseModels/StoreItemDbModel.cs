using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace MyShoppingApp.Infrastructure.SupabaseModels;

[Table("store_items")]
public class StoreItemDbModel : BaseModel
{
    [PrimaryKey("store_id")]
    public Guid StoreId { get; set; }

    [PrimaryKey("item_id")]
    public Guid ItemId { get; set; }

    [Column("price")]
    public decimal? Price { get; set; }

    [Column("aisle")]
    public string Aisle { get; set; } = string.Empty;

    [Column("notes")]
    public string Notes { get; set; } = string.Empty;
} 