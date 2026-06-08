#nullable enable

using DungMoHinh.Models;

namespace DungMoHinh.Repositories.Interfaces;

public interface IKhoAnhTaiLen : IKhoDuLieu<AnhTaiLen>
{
    Task<List<AnhTaiLen>> GetUserAnhTaiLensAsync(string userId);

    Task<AnhTaiLen?> LayAnhTaiLenCuaNguoiDungAsync(int id, string userId);

    Task<AnhTaiLen?> LayAnhTaiLenKemPhanTichAsync(int id, string userId);
}


