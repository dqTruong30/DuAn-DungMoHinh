#nullable enable

using DungMoHinh.Models;

namespace DungMoHinh.Repositories.Interfaces;

public interface IKhoTuyChinh
{
    Task<ThamSoTuyChinh?> GetActiveParameterAsync(int id);

    Task<GiaTriTuyChinhNhanVat?> GetNhanVatGiaTriAsync(int nhanVatId, int parameterId);

    Task AddNhanVatGiaTriAsync(GiaTriTuyChinhNhanVat value);
}


