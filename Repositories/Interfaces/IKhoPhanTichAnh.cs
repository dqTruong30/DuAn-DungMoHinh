#nullable enable

using DungMoHinh.Models;

namespace DungMoHinh.Repositories.Interfaces;

public interface IKhoPhanTichAnh : IKhoDuLieu<KetQuaPhanTichAnh>
{
    Task<KetQuaPhanTichAnh?> LayTheoAnhTaiLenIdAsync(int anhTaiLenId);
}


