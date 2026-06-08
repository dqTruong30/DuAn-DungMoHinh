#nullable enable

using DungMoHinh.Models;
using DungMoHinh.ViewModels;

namespace DungMoHinh.Repositories.Interfaces;

public interface IKhoQuanTri
{
    Task<TongQuanQuanTri> LayTongQuanBangDieuKhienAsync();

    Task<List<NhanVat>> LayNhanVatGanDayAsync(int take = 200);

    Task<List<TaiNguyen3D>> GetTaiNguyensAsync();

    Task<List<AnhTaiLen>> GetRecentAnhTaiLensAsync(int take = 200);
}


