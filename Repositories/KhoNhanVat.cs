#nullable enable

using DungMoHinh.Data;
using DungMoHinh.Models;
using DungMoHinh.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DungMoHinh.Repositories;

public class KhoNhanVat : KhoDuLieuCoSo<NhanVat>, IKhoNhanVat
{
    public KhoNhanVat(ApplicationDbContext context)
        : base(context)
    {
    }

    public async Task<List<NhanVat>> LayNhanVatTheoNguoiDungAsync(string userId)
    {
        return await Set
            .Where(nhanVat => nhanVat.UserId == userId)
            .OrderByDescending(nhanVat => nhanVat.UpdatedAt ?? nhanVat.CreatedAt)
            .ToListAsync();
    }

    public async Task<NhanVat?> LayNhanVatCuaNguoiDungAsync(int id, string userId)
    {
        return await Set.FirstOrDefaultAsync(nhanVat => nhanVat.Id == id && nhanVat.UserId == userId);
    }

    public async Task<NhanVat?> LayNhanVatChoTrinhSuaAsync(int id, string userId)
    {
        return await Set
            .Include(nhanVat => nhanVat.MauNhanVat)
            .Include(nhanVat => nhanVat.CauHinhCoThe)
            .Include(nhanVat => nhanVat.CauHinhKhuonMat)
            .Include(nhanVat => nhanVat.TaiNguyenNhanVats)
                .ThenInclude(nhanVatTaiNguyen => nhanVatTaiNguyen.TaiNguyen3D)
            .Include(nhanVat => nhanVat.TaiNguyenNhanVats)
                .ThenInclude(nhanVatTaiNguyen => nhanVatTaiNguyen.GiaTriTungPhan)
            .Include(nhanVat => nhanVat.TuyChinhGiaTris)
                .ThenInclude(value => value.ThamSoTuyChinh)
            .Include(nhanVat => nhanVat.AnhThamChieus)
            .Include(nhanVat => nhanVat.Xuats)
            .FirstOrDefaultAsync(nhanVat => nhanVat.Id == id && nhanVat.UserId == userId);
    }

    public async Task<bool> NguoiDungSoHuuNhanVatAsync(int id, string userId)
    {
        return await Set.AnyAsync(nhanVat => nhanVat.Id == id && nhanVat.UserId == userId);
    }

    public async Task TouchAsync(int id)
    {
        var nhanVat = await Set.FirstAsync(item => item.Id == id);
        nhanVat.UpdatedAt = DateTime.UtcNow;
    }
}


