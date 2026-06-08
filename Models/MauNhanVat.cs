#nullable enable

using System.ComponentModel.DataAnnotations;

namespace DungMoHinh.Models;

public class MauNhanVat : ThucTheCoSo
{
    [Required]
    [MaxLength(120)]
    public string Name { get; set; } = string.Empty;

    [MaxLength(1000)]
    public string? MoTa { get; set; }

    public LoaiNhanVat Kind { get; set; } = LoaiNhanVat.TrungTinh;

    public PhongCachNhanVat Style { get; set; } = PhongCachNhanVat.BinhThuong;

    [Required]
    [MaxLength(500)]
    public string ModelUrl { get; set; } = string.Empty;

    [MaxLength(500)]
    public string? AnhDaiDienUrl { get; set; }

    public bool IsActive { get; set; } = true;

    public ICollection<NhanVat> NhanVats { get; set; } = new HashSet<NhanVat>();
}


