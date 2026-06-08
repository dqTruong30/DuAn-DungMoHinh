#nullable enable

namespace DungMoHinh.Models;

public abstract class ThucTheCoSo
{
    public int Id { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime? UpdatedAt { get; set; }
}

