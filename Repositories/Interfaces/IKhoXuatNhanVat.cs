#nullable enable

using DungMoHinh.Models;

namespace DungMoHinh.Repositories.Interfaces;

public interface IKhoXuatNhanVat : IKhoDuLieu<XuatNhanVat>
{
    Task<XuatNhanVat?> LayXuatNhanVatCuaNguoiDungAsync(int id, string userId);

    Task<List<XuatNhanVat>> GetXuatNhanVatsAsync(int nhanVatId, string userId);
}


