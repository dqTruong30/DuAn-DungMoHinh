#nullable enable

using DungMoHinh.Models;

namespace DungMoHinh.ViewModels;

public class YeuCauTaoXuat
{
    public DinhDangXuat Format { get; set; } = DinhDangXuat.Png;
}

public class YeuCauHoanTatXuat
{
    public string DuongDanFile { get; set; } = string.Empty;

    public string? TenFile { get; set; }

    public long KichThuocFile { get; set; }
}

