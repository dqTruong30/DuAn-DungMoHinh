#nullable enable

using DungMoHinh.Data;
using DungMoHinh.Models;
using DungMoHinh.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DungMoHinh.Repositories;

public class KhoPhanTichAnh : KhoDuLieuCoSo<KetQuaPhanTichAnh>, IKhoPhanTichAnh
{
    public KhoPhanTichAnh(ApplicationDbContext context)
        : base(context)
    {
    }

    public async Task<KetQuaPhanTichAnh?> LayTheoAnhTaiLenIdAsync(int anhTaiLenId)
    {
        return await Set.FirstOrDefaultAsync(result => result.AnhTaiLenId == anhTaiLenId);
    }
}


