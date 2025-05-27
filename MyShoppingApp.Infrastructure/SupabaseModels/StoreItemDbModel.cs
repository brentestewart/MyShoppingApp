using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace MyShoppingApp.Infrastructure.SupabaseModels;

[Table("storeitems")]
public class StoreItemDbModel : BaseModel
{
    [PrimaryKey("store_id")]
    [Column("store_id")]
    public Guid StoreId { get; set; }

    [PrimaryKey("item_id")]
    [Column("item_id")]
    public Guid ItemId { get; set; }

    [Column("price")]
    public decimal? Price { get; set; }

    [Column("aisle")]
    public string Aisle { get; set; } = string.Empty;

    [Column("notes")]
    public string Notes { get; set; } = string.Empty;
} 