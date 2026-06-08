#nullable enable

using DungMoHinh.Models;

namespace DungMoHinh.Repositories.Interfaces;

public interface IKhoNhanVat : IKhoDuLieu<NhanVat>
{
    Task<List<NhanVat>> LayNhanVatTheoNguoiDungAsync(string userId);

    Task<NhanVat?> LayNhanVatCuaNguoiDungAsync(int id, string userId);

    Task<NhanVat?> LayNhanVatChoTrinhSuaAsync(int id, string userId);

    Task<bool> NguoiDungSoHuuNhanVatAsync(int id, string userId);

    Task TouchAsync(int id);
}


