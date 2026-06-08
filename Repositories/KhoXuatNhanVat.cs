#nullable enable

using DungMoHinh.Data;
using DungMoHinh.Models;
using DungMoHinh.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DungMoHinh.Repositories;

public class KhoXuatNhanVat : KhoDuLieuCoSo<XuatNhanVat>, IKhoXuatNhanVat
{
    public KhoXuatNhanVat(ApplicationDbContext context)
        : base(context)
    {
    }

    public async Task<XuatNhanVat?> LayXuatNhanVatCuaNguoiDungAsync(int id, string userId)
    {
        return await Set
            .Include(xuat => xuat.NhanVat)
            .FirstOrDefaultAsync(xuat => xuat.Id == id && xuat.NhanVat.UserId == userId);
    }

    public async Task<List<XuatNhanVat>> GetXuatNhanVatsAsync(int nhanVatId, string userId)
    {
        return await Set
            .Include(xuat => xuat.NhanVat)
            .Where(xuat => xuat.NhanVatId == nhanVatId && xuat.NhanVat.UserId == userId)
            .OrderByDescending(xuat => xuat.CreatedAt)
            .ToListAsync();
    }
}


