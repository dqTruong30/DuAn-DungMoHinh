#nullable enable

using DungMoHinh.Models;

namespace DungMoHinh.ViewModels;

public class YeuCauTaoTaiNguyen
{
    public string Name { get; set; } = string.Empty;

    public string? MoTa { get; set; }

    public LoaiTaiNguyen Type { get; set; }

    public DiemGan DefaultDiemGan { get; set; } = DiemGan.TuyChinh;

    public string DuongDanFile { get; set; } = string.Empty;

    public string? AnhDaiDienUrl { get; set; }

    public string? KetCauUrl { get; set; }

    public string? MauSacMacDinh { get; set; }

    public bool SupportsPartAdjustment { get; set; }

    public bool IsUserGenerated { get; set; }
}

public class YeuCauSuaTaiNguyen : YeuCauTaoTaiNguyen
{
    public int Id { get; set; }

    public bool IsActive { get; set; } = true;
}

public class YeuCauGanTaiNguyenNhanVat
{
    public int TaiNguyen3DId { get; set; }

    public DiemGan DiemGan { get; set; } = DiemGan.TuyChinh;

    public string? TenDiemGanTuyChinh { get; set; }

    public string? MauSac { get; set; }
}

public class YeuCauCapNhatPhuKienNhanVat : YeuCauBienDoiTaiNguyen
{
    public int NhanVatId { get; set; }

    public int TaiNguyenNhanVatId { get; set; }
}

public class TaiNguyenNhanVatCreateRequest
{
    public int TaiNguyen3DId { get; set; }

    public DiemGan DiemGan { get; set; } = DiemGan.TuyChinh;

    public string? TenDiemGanTuyChinh { get; set; }

    public string? MauSac { get; set; }
}

public class YeuCauBienDoiTaiNguyen
{
    public decimal ViTriX { get; set; }
    public decimal ViTriY { get; set; }
    public decimal ViTriZ { get; set; }
    public decimal XoayX { get; set; }
    public decimal XoayY { get; set; }
    public decimal XoayZ { get; set; }
    public decimal TiLeX { get; set; } = 1.00m;
    public decimal TiLeY { get; set; } = 1.00m;
    public decimal TiLeZ { get; set; } = 1.00m;
    public string? MauSac { get; set; }
    public decimal DoKimLoai { get; set; }
    public decimal DoNham { get; set; } = 0.50m;
}

public class YeuCauGiaTriPhanTaiNguyen
{
    public int DiemChinhPhuKienId { get; set; }

    public decimal GiaTri { get; set; } = 1.00m;
}

