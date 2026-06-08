#nullable enable

using DungMoHinh.Models;

namespace DungMoHinh.Repositories.Interfaces;

public interface IKhoGoiMau : IKhoDuLieu<GoiMauThietLap>
{
    Task<List<GoiMauThietLap>> GetActiveGoiMausAsync();

    Task<GoiMauThietLap?> LayGoiMauDangHoatDongAsync(int id);
}


