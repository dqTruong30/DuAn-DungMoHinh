#nullable enable

using DungMoHinh.Data;
using DungMoHinh.Models;
using DungMoHinh.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DungMoHinh.Repositories;

public class KhoTaiNguyen : KhoDuLieuCoSo<TaiNguyen3D>, IKhoTaiNguyen
{
    public KhoTaiNguyen(ApplicationDbContext context)
        : base(context)
    {
    }

    public async Task<List<TaiNguyen3D>> LayTatCaTaiNguyenAsync(LoaiTaiNguyen? type = null)
    {
        IQueryable<TaiNguyen3D> query = Set.Include(taiNguyen => taiNguyen.AdjustmentPoints);

        if (type.HasValue)
        {
            query = query.Where(taiNguyen => taiNguyen.Type == type.Value);
        }

        return await query
            .OrderBy(taiNguyen => taiNguyen.IsActive ? 0 : 1)
            .ThenBy(taiNguyen => taiNguyen.Type)
            .ThenBy(taiNguyen => taiNguyen.Name)
            .ToListAsync();
    }

    public async Task<List<TaiNguyen3D>> GetActiveTaiNguyensAsync(LoaiTaiNguyen? type = null)
    {
        IQueryable<TaiNguyen3D> query = Set
            .Include(taiNguyen => taiNguyen.AdjustmentPoints)
            .Where(taiNguyen => taiNguyen.IsActive);

        if (type.HasValue)
        {
            query = query.Where(taiNguyen => taiNguyen.Type == type.Value);
        }

        return await query
            .OrderBy(taiNguyen => taiNguyen.Type)
            .ThenBy(taiNguyen => taiNguyen.Name)
            .ToListAsync();
    }

    public async Task<TaiNguyen3D?> LayTaiNguyenKemDiemAsync(int id)
    {
        return await Set
            .Include(taiNguyen => taiNguyen.AdjustmentPoints)
            .FirstOrDefaultAsync(taiNguyen => taiNguyen.Id == id);
    }

    public async Task<TaiNguyen3D?> LayTaiNguyenDangHoatDongKemDiemAsync(int id)
    {
        return await Set
            .Include(taiNguyen => taiNguyen.AdjustmentPoints)
            .FirstOrDefaultAsync(taiNguyen => taiNguyen.Id == id && taiNguyen.IsActive);
    }

    public async Task<DiemChinhPhuKien?> GetAdjustmentPointAsync(int taiNguyenId, int adjustmentPointId)
    {
        return await Context.DiemChinhPhuKiens
            .FirstOrDefaultAsync(point => point.Id == adjustmentPointId && point.TaiNguyen3DId == taiNguyenId);
    }

    public async Task<bool> DisableAsync(int id)
    {
        var taiNguyen = await Set.FindAsync(id);
        if (taiNguyen is null)
        {
            return false;
        }

        taiNguyen.IsActive = false;
        taiNguyen.UpdatedAt = DateTime.UtcNow;
        return true;
    }
}


