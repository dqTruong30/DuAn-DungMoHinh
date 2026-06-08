#nullable enable

using DungMoHinh.Data;
using DungMoHinh.Models;
using DungMoHinh.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DungMoHinh.Repositories;

public class KhoAnhTaiLen : KhoDuLieuCoSo<AnhTaiLen>, IKhoAnhTaiLen
{
    public KhoAnhTaiLen(ApplicationDbContext context)
        : base(context)
    {
    }

    public async Task<List<AnhTaiLen>> GetUserAnhTaiLensAsync(string userId)
    {
        return await Set
            .Where(anhTaiLen => anhTaiLen.UserId == userId)
            .OrderByDescending(anhTaiLen => anhTaiLen.CreatedAt)
            .ToListAsync();
    }

    public async Task<AnhTaiLen?> LayAnhTaiLenCuaNguoiDungAsync(int id, string userId)
    {
        return await Set.FirstOrDefaultAsync(anhTaiLen => anhTaiLen.Id == id && anhTaiLen.UserId == userId);
    }

    public async Task<AnhTaiLen?> LayAnhTaiLenKemPhanTichAsync(int id, string userId)
    {
        return await Set
            .Include(anhTaiLen => anhTaiLen.AnalysisResult)
            .FirstOrDefaultAsync(anhTaiLen => anhTaiLen.Id == id && anhTaiLen.UserId == userId);
    }
}


