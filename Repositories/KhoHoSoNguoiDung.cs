#nullable enable

using DungMoHinh.Data;
using DungMoHinh.Models;
using DungMoHinh.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DungMoHinh.Repositories;

public class KhoHoSoNguoiDung : KhoDuLieuCoSo<HoSoNguoiDung>, IKhoHoSoNguoiDung
{
    public KhoHoSoNguoiDung(ApplicationDbContext context)
        : base(context)
    {
    }

    public async Task<HoSoNguoiDung?> LayTheoNguoiDungIdAsync(string userId)
    {
        return await Set.FirstOrDefaultAsync(hoSo => hoSo.UserId == userId);
    }

    public async Task<HoSoNguoiDung> LayHoacTaoMoiAsync(string userId, string displayName)
    {
        var hoSo = await LayTheoNguoiDungIdAsync(userId);
        if (hoSo is not null)
        {
            return hoSo;
        }

        hoSo = new HoSoNguoiDung
        {
            UserId = userId,
            TenHienThi = displayName
        };

        await AddAsync(hoSo);
        return hoSo;
    }
}


