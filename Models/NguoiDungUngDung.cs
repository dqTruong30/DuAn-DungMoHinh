#nullable enable

using Microsoft.AspNetCore.Identity;

namespace DungMoHinh.Models;

public class NguoiDungUngDung : IdentityUser
{
    public string TenHienThi { get; set; } = string.Empty;
}
