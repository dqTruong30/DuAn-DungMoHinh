#nullable enable

using System.ComponentModel.DataAnnotations;

namespace DungMoHinh.Models;

public class AnhTaiLen : ThucTheCoSo
{
    [Required]
    [MaxLength(450)]
    public string UserId { get; set; } = string.Empty;

    public int? HoSoNguoiDungId { get; set; }

    public HoSoNguoiDung? HoSoNguoiDung { get; set; }

    public int? NhanVatId { get; set; }

    public NhanVat? NhanVat { get; set; }

    public LoaiTaiLen LoaiTaiLen { get; set; }

    public TrangThaiXuLy Status { get; set; } = TrangThaiXuLy.ChoXuLy;

    [Required]
    [MaxLength(500)]
    public string DuongDanAnhGoc { get; set; } = string.Empty;

    [MaxLength(500)]
    public string? DuongDanAnhDaXuLy { get; set; }

    [MaxLength(500)]
    public string? AnhDaiDienUrl { get; set; }

    [MaxLength(120)]
    public string? TenFile { get; set; }

    [MaxLength(120)]
    public string? LoaiNoiDung { get; set; }

    public long KichThuocFile { get; set; }

    public KetQuaPhanTichAnh? AnalysisResult { get; set; }
}


