#nullable enable

using DungMoHinh.Data;
using DungMoHinh.Models;
using DungMoHinh.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DungMoHinh.Repositories;

public class KhoTuyChinh : IKhoTuyChinh
{
    private readonly ApplicationDbContext _context;

    public KhoTuyChinh(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ThamSoTuyChinh?> GetActiveParameterAsync(int id)
    {
        return await _context.ThamSoTuyChinhs
            .FirstOrDefaultAsync(parameter => parameter.Id == id && parameter.IsActive);
    }

    public async Task<GiaTriTuyChinhNhanVat?> GetNhanVatGiaTriAsync(int nhanVatId, int parameterId)
    {
        return await _context.GiaTriTuyChinhNhanVats
            .FirstOrDefaultAsync(value =>
                value.NhanVatId == nhanVatId &&
                value.ThamSoTuyChinhId == parameterId);
    }

    public async Task AddNhanVatGiaTriAsync(GiaTriTuyChinhNhanVat value)
    {
        await _context.GiaTriTuyChinhNhanVats.AddAsync(value);
    }
}


