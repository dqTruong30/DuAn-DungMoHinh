#nullable enable

using System.ComponentModel.DataAnnotations;

namespace DungMoHinh.ViewModels;

public class YeuCauDangNhap
{
    [Required(ErrorMessage = "Email là bắt buộc.")]
    [EmailAddress(ErrorMessage = "Email không hợp lệ.")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Mật khẩu là bắt buộc.")]
    [DataType(DataType.Password)]
    public string MatKhau { get; set; } = string.Empty;

    public bool GhiNhoDangNhap { get; set; }

    public string? ReturnUrl { get; set; }
}

public class YeuCauDangKy
{
    [Required(ErrorMessage = "Tên hiển thị là bắt buộc.")]
    [MaxLength(120, ErrorMessage = "Tên hiển thị tối đa 120 ký tự.")]
    public string TenHienThi { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email là bắt buộc.")]
    [EmailAddress(ErrorMessage = "Email không hợp lệ.")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Mật khẩu là bắt buộc.")]
    [DataType(DataType.Password)]
    [MinLength(6, ErrorMessage = "Mật khẩu cần ít nhất 6 ký tự.")]
    public string MatKhau { get; set; } = string.Empty;

    [Required(ErrorMessage = "Vui lòng nhập lại mật khẩu.")]
    [DataType(DataType.Password)]
    [Compare(nameof(MatKhau), ErrorMessage = "Mật khẩu nhập lại không khớp.")]
    public string XacNhanMatKhau { get; set; } = string.Empty;
}
