#nullable enable

using System.ComponentModel.DataAnnotations;

namespace DungMoHinh.Models;

public class GoiMauThietLap : ThucTheCoSo
{
    [Required]
    [MaxLength(120)]
    public string Name { get; set; } = string.Empty;

    [MaxLength(1000)]
    public string? MoTa { get; set; }

    public LoaiNhanVat Kind { get; set; } = LoaiNhanVat.TrungTinh;

    public PhongCachNhanVat Style { get; set; } = PhongCachNhanVat.BinhThuong;

    public int? MauNhanVatId { get; set; }

    public MauNhanVat? MauNhanVat { get; set; }

    [MaxLength(500)]
    public string? AnhDaiDienUrl { get; set; }

    [MaxLength(4000)]
    public string? DefaultSettingsJson { get; set; }

    public bool IsActive { get; set; } = true;
}

