#nullable enable

using DungMoHinh.Data;
using DungMoHinh.Models;
using DungMoHinh.Repositories.Interfaces;
using DungMoHinh.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace DungMoHinh.Repositories;

public class KhoQuanTri : IKhoQuanTri
{
    private readonly ApplicationDbContext _context;

    public KhoQuanTri(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<TongQuanQuanTri> LayTongQuanBangDieuKhienAsync()
    {
        return new TongQuanQuanTri
        {
            UserCount = await _context.HoSoNguoiDungs.CountAsync(),
            NhanVatCount = await _context.NhanVats.CountAsync(),
            MauCount = await _context.MauNhanVats.CountAsync(),
            TaiNguyenCount = await _context.TaiNguyens3D.CountAsync(),
            TaiLenCount = await _context.AnhTaiLens.CountAsync(),
            XuatCount = await _context.XuatNhanVats.CountAsync()
        };
    }

    public async Task<List<NhanVat>> LayNhanVatGanDayAsync(int take = 200)
    {
        return await _context.NhanVats
            .Include(nhanVat => nhanVat.MauNhanVat)
            .OrderByDescending(nhanVat => nhanVat.CreatedAt)
            .Take(take)
            .ToListAsync();
    }

    public async Task<List<TaiNguyen3D>> GetTaiNguyensAsync()
    {
        return await _context.TaiNguyens3D
            .OrderBy(taiNguyen => taiNguyen.Type)
            .ThenBy(taiNguyen => taiNguyen.Name)
            .ToListAsync();
    }

    public async Task<List<AnhTaiLen>> GetRecentAnhTaiLensAsync(int take = 200)
    {
        return await _context.AnhTaiLens
            .OrderByDescending(anhTaiLen => anhTaiLen.CreatedAt)
            .Take(take)
            .ToListAsync();
    }
}


