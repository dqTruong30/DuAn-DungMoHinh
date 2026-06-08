#nullable enable

using DungMoHinh.Data;
using DungMoHinh.Models;
using DungMoHinh.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DungMoHinh.Repositories;

public class KhoTaiNguyenNhanVat : KhoDuLieuCoSo<TaiNguyenNhanVat>, IKhoTaiNguyenNhanVat
{
    public KhoTaiNguyenNhanVat(ApplicationDbContext context)
        : base(context)
    {
    }

    public async Task<TaiNguyenNhanVat?> LayTaiNguyenNhanVatCuaNguoiDungAsync(int id, string userId)
    {
        return await Set
            .Include(item => item.NhanVat)
            .FirstOrDefaultAsync(item => item.Id == id && item.NhanVat.UserId == userId);
    }

    public async Task<TaiNguyenNhanVat?> LayTaiNguyenNhanVatKemTaiNguyenAsync(int id, string userId)
    {
        return await Set
            .Include(item => item.NhanVat)
            .Include(item => item.TaiNguyen3D)
            .FirstOrDefaultAsync(item => item.Id == id && item.NhanVat.UserId == userId);
    }

    public async Task<GiaTriPhanPhuKienNhanVat?> GetPartGiaTriAsync(int nhanVatTaiNguyenId, int adjustmentPointId)
    {
        return await Context.GiaTriPhanPhuKienNhanVats
            .FirstOrDefaultAsync(item =>
                item.TaiNguyenNhanVatId == nhanVatTaiNguyenId &&
                item.DiemChinhPhuKienId == adjustmentPointId);
    }

    public async Task AddPartGiaTriAsync(GiaTriPhanPhuKienNhanVat value)
    {
        await Context.GiaTriPhanPhuKienNhanVats.AddAsync(value);
    }
}


