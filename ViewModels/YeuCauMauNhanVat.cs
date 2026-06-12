#nullable enable

using DungMoHinh.Models;

namespace DungMoHinh.ViewModels;

public class YeuCauMauNhanVat
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string? MoTa { get; set; }

    public LoaiNhanVat Kind { get; set; } = LoaiNhanVat.TrungTinh;

    public PhongCachNhanVat Style { get; set; } = PhongCachNhanVat.BinhThuong;

    public string ModelUrl { get; set; } = string.Empty;

    public string? AnhDaiDienUrl { get; set; }

    public bool IsActive { get; set; } = true;
}
