#nullable enable

using DungMoHinh.Models;

namespace DungMoHinh.Repositories.Interfaces;

public interface IKhoTaiNguyen : IKhoDuLieu<TaiNguyen3D>
{
    Task<List<TaiNguyen3D>> GetActiveTaiNguyensAsync(LoaiTaiNguyen? type = null);

    Task<TaiNguyen3D?> LayTaiNguyenDangHoatDongKemDiemAsync(int id);

    Task<DiemChinhPhuKien?> GetAdjustmentPointAsync(int taiNguyenId, int adjustmentPointId);

    Task<bool> DisableAsync(int id);
}


