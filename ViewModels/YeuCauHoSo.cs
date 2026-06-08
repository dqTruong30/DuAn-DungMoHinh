#nullable enable

namespace DungMoHinh.ViewModels;

public class HoSoNguoiDungUpdateRequest
{
    public string TenHienThi { get; set; } = string.Empty;

    public string? AvatarUrl { get; set; }

    public string? Bio { get; set; }
}

