#nullable enable

using DungMoHinh.Models;

namespace DungMoHinh.Repositories.Interfaces;

public interface IKhoHoSoNguoiDung : IKhoDuLieu<HoSoNguoiDung>
{
    Task<HoSoNguoiDung?> LayTheoNguoiDungIdAsync(string userId);

    Task<HoSoNguoiDung> LayHoacTaoMoiAsync(string userId, string displayName);
}


