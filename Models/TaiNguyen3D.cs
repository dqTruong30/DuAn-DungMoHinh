#nullable enable

using System.ComponentModel.DataAnnotations;

namespace DungMoHinh.Models;

public class TaiNguyen3D : ThucTheCoSo
{
    [Required]
    [MaxLength(120)]
    public string Name { get; set; } = string.Empty;

    [MaxLength(1000)]
    public string? MoTa { get; set; }

    public LoaiTaiNguyen Type { get; set; }

    public DiemGan DefaultDiemGan { get; set; } = DiemGan.TuyChinh;

    [Required]
    [MaxLength(500)]
    public string DuongDanFile { get; set; } = string.Empty;

    [MaxLength(500)]
    public string? AnhDaiDienUrl { get; set; }

    [MaxLength(500)]
    public string? KetCauUrl { get; set; }

    [MaxLength(32)]
    public string? MauSacMacDinh { get; set; }

    public bool SupportsPartAdjustment { get; set; }

    public bool IsUserGenerated { get; set; }

    public bool IsActive { get; set; } = true;

    public ICollection<TaiNguyenNhanVat> TaiNguyenNhanVats { get; set; } = new HashSet<TaiNguyenNhanVat>();

    public ICollection<DiemChinhPhuKien> AdjustmentPoints { get; set; } = new HashSet<DiemChinhPhuKien>();
}

