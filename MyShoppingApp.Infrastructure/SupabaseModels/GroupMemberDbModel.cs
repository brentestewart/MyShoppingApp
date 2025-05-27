using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace MyShoppingApp.Infrastructure.SupabaseModels;

[Table("group_members")]
public class GroupMemberDbModel : BaseModel
{
    [PrimaryKey("user_id", false)]
    [Column("user_id")]
    public Guid UserId { get; set; }

    [PrimaryKey("group_id", false)]
    [Column("group_id")]
    public Guid GroupId { get; set; }

    [Column("role")]
    public string? Role { get; set; }

    [Column("joined_at")]
    public DateTime? JoinedAt { get; set; }
} 