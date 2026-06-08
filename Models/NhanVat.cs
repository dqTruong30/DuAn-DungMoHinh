#nullable enable

using System.ComponentModel.DataAnnotations;

namespace DungMoHinh.Models;

public class NhanVat : ThucTheCoSo
{
    [Required]
    [MaxLength(120)]
    public string Name { get; set; } = string.Empty;

    [MaxLength(1000)]
    public string? MoTa { get; set; }

    [Required]
    [MaxLength(450)]
    public string UserId { get; set; } = string.Empty;

    public int? HoSoNguoiDungId { get; set; }

    public HoSoNguoiDung? HoSoNguoiDung { get; set; }

    public int? MauNhanVatId { get; set; }

    public MauNhanVat? MauNhanVat { get; set; }

    public LoaiNhanVat Kind { get; set; } = LoaiNhanVat.TrungTinh;

    public PhongCachNhanVat Style { get; set; } = PhongCachNhanVat.BinhThuong;

    public CheDoHienThi CheDoHienThi { get; set; } = CheDoHienThi.RiengTu;

    [MaxLength(500)]
    public string? AnhDaiDienUrl { get; set; }

    [MaxLength(500)]
    public string? AnhXemTruocUrl { get; set; }

    public bool IsFavorite { get; set; }

    public CauHinhCoTheNhanVat? CauHinhCoThe { get; set; }

    public CauHinhKhuonMatNhanVat? CauHinhKhuonMat { get; set; }

    public ICollection<TaiNguyenNhanVat> TaiNguyenNhanVats { get; set; } = new HashSet<TaiNguyenNhanVat>();

    public ICollection<GiaTriTuyChinhNhanVat> TuyChinhGiaTris { get; set; } = new HashSet<GiaTriTuyChinhNhanVat>();

    public ICollection<AnhTaiLen> AnhThamChieus { get; set; } = new HashSet<AnhTaiLen>();

    public ICollection<XuatNhanVat> Xuats { get; set; } = new HashSet<XuatNhanVat>();
}


