#nullable enable

using System.ComponentModel.DataAnnotations;

namespace DungMoHinh.Models;

public class XuatNhanVat : ThucTheCoSo
{
    public int NhanVatId { get; set; }

    public NhanVat NhanVat { get; set; } = null!;

    public DinhDangXuat Format { get; set; }

    public TrangThaiXuLy Status { get; set; } = TrangThaiXuLy.ChoXuLy;

    [MaxLength(500)]
    public string? DuongDanFile { get; set; }

    [MaxLength(120)]
    public string? TenFile { get; set; }

    public long KichThuocFile { get; set; }

    [MaxLength(1000)]
    public string? ThongBaoLoi { get; set; }
}


