#nullable enable

using System.ComponentModel.DataAnnotations;

namespace DungMoHinh.Models;

public class HoSoNguoiDung : ThucTheCoSo
{
    [Required]
    [MaxLength(450)]
    public string UserId { get; set; } = string.Empty;

    [Required]
    [MaxLength(120)]
    public string TenHienThi { get; set; } = string.Empty;

    [MaxLength(500)]
    public string? AvatarUrl { get; set; }

    [MaxLength(1000)]
    public string? Bio { get; set; }

    public ICollection<NhanVat> NhanVats { get; set; } = new HashSet<NhanVat>();

    public ICollection<AnhTaiLen> AnhTaiLens { get; set; } = new HashSet<AnhTaiLen>();
}


