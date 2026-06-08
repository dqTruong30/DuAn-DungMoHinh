#nullable enable

using DungMoHinh.Data;
using DungMoHinh.Models;
using DungMoHinh.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DungMoHinh.Repositories;

public class KhoMauNhanVat : KhoDuLieuCoSo<MauNhanVat>, IKhoMauNhanVat
{
    public KhoMauNhanVat(ApplicationDbContext context)
        : base(context)
    {
    }

    public async Task<List<MauNhanVat>> LayMauDangHoatDongAsync()
    {
        return await Set
            .Where(mau => mau.IsActive)
            .OrderBy(mau => mau.Style)
            .ThenBy(mau => mau.Kind)
            .ThenBy(mau => mau.Name)
            .ToListAsync();
    }

    public async Task<MauNhanVat?> LayMauDangHoatDongAsync(int id)
    {
        return await Set.FirstOrDefaultAsync(mau => mau.Id == id && mau.IsActive);
    }
}


