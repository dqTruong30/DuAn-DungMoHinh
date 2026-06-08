#nullable enable

using DungMoHinh.Data;
using DungMoHinh.Models;
using DungMoHinh.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DungMoHinh.Repositories;

public class KhoGoiMau : KhoDuLieuCoSo<GoiMauThietLap>, IKhoGoiMau
{
    public KhoGoiMau(ApplicationDbContext context)
        : base(context)
    {
    }

    public async Task<List<GoiMauThietLap>> GetActiveGoiMausAsync()
    {
        return await Set
            .Include(goiMau => goiMau.MauNhanVat)
            .Where(goiMau => goiMau.IsActive)
            .OrderBy(goiMau => goiMau.Style)
            .ThenBy(goiMau => goiMau.Kind)
            .ThenBy(goiMau => goiMau.Name)
            .ToListAsync();
    }

    public async Task<GoiMauThietLap?> LayGoiMauDangHoatDongAsync(int id)
    {
        return await Set
            .Include(goiMau => goiMau.MauNhanVat)
            .FirstOrDefaultAsync(goiMau => goiMau.Id == id && goiMau.IsActive);
    }
}


