#nullable enable

using DungMoHinh.Models;

namespace DungMoHinh.Repositories.Interfaces;

public interface IKhoTaiNguyenNhanVat : IKhoDuLieu<TaiNguyenNhanVat>
{
    Task<TaiNguyenNhanVat?> LayTaiNguyenNhanVatCuaNguoiDungAsync(int id, string userId);

    Task<TaiNguyenNhanVat?> LayTaiNguyenNhanVatKemTaiNguyenAsync(int id, string userId);

    Task<GiaTriPhanPhuKienNhanVat?> GetPartGiaTriAsync(int nhanVatTaiNguyenId, int adjustmentPointId);

    Task AddPartGiaTriAsync(GiaTriPhanPhuKienNhanVat value);
}


