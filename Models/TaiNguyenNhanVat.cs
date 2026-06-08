#nullable enable

using System.ComponentModel.DataAnnotations;

namespace DungMoHinh.Models;

public class TaiNguyenNhanVat : ThucTheCoSo
{
    public int NhanVatId { get; set; }

    public NhanVat NhanVat { get; set; } = null!;

    public int TaiNguyen3DId { get; set; }

    public TaiNguyen3D TaiNguyen3D { get; set; } = null!;

    public DiemGan DiemGan { get; set; } = DiemGan.TuyChinh;

    [MaxLength(120)]
    public string? TenDiemGanTuyChinh { get; set; }

    public decimal ViTriX { get; set; }

    public decimal ViTriY { get; set; }

    public decimal ViTriZ { get; set; }

    public decimal XoayX { get; set; }

    public decimal XoayY { get; set; }

    public decimal XoayZ { get; set; }

    public decimal TiLeX { get; set; } = 1.00m;

    public decimal TiLeY { get; set; } = 1.00m;

    public decimal TiLeZ { get; set; } = 1.00m;

    [MaxLength(32)]
    public string? MauSac { get; set; }

    public decimal DoKimLoai { get; set; }

    public decimal DoNham { get; set; } = 0.50m;

    public ICollection<GiaTriPhanPhuKienNhanVat> GiaTriTungPhan { get; set; } = new HashSet<GiaTriPhanPhuKienNhanVat>();
}


